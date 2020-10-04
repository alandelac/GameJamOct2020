using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{
    // Start is called before the first frame update

    public spawnEnemigos enemigos;

    public float maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;
    public int contadorDeDesaparecer=10;
    bool inmortal = false;
    AudioSource sound;

    public int contadorEnemigos;
    public string sceneName;

    void Start()
    {
        contadorEnemigos = enemigos.contCalabazas+enemigos.contEnemigo2+enemigos.contEnemigo3;
        sound = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (contadorEnemigos <= 0)
        {
            PlayGame(sceneName);
        }

    }

    

    

    public void PlayGame(string sceneGame)
    {
        SceneManager.LoadScene(sceneGame);
    }

    public void TakeDamage(float damage)
    {
        if (inmortal == false)
        {
            inmortal = true;
            currentHealth = currentHealth - damage;
            healthBar.SetHealth(currentHealth);
            Invoke("desaparecer", 0f);
            sound.Play();
        }

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Perdiste");
        }

    }

    void desaparecer()
    {
        if (this.gameObject.GetComponent<SpriteRenderer>().enabled)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        contadorDeDesaparecer--;

        if (contadorDeDesaparecer <= 0f)
        {
            //CancelInvoke("desaparecer");
            contadorDeDesaparecer=10;
            inmortal = false;
        }
        else{
            Invoke("desaparecer",0.5f);
        }

    }
}

