using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class ControlEnemigo : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 2f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    GameObject nino;
    public float dano=5;
    bool haceDano = true;
    public float error = 0.2f;
    public float Vida;
    float currentVida;
    public HealthBar healthbar;


    private void Start()
    {
        currentVida = Vida;
        healthbar.SetMaxHealth(currentVida);
        nino = GameObject.Find("nino");
    }
    

    // Update is called once per frame
    void Update()
    {
        Vector2 posicionNino = nino.transform.position;


        if (posicionNino.x - rb.position.x < -error)
        {
            movement.x = -1f;
        }
        else if(posicionNino.x - rb.position.x > error)
        {
            movement.x = 1f;
        }
        else
        {
            movement.x = 0f;
        }
        if (posicionNino.y - rb.position.y < -error)
        {
            movement.y = -1f;
        }
        else if(posicionNino.y - rb.position.y > error)
        {
            movement.y = 1f;
        }
        else
        {
            movement.y = 0f;
        }
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        this.gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
        Invoke("ponerTrigger", 5f);
        if (other.gameObject.Equals(nino))
        {
            if (haceDano)
            {
                nino.GetComponent<Interaction>().TakeDamage(dano);
                haceDano = false;
            }
        }
            
    }

    private void ponerTrigger()
    {
        this.gameObject.GetComponent<CircleCollider2D>().isTrigger=true;
        haceDano = true;
    }

    public void takeDamage(float damage)
    {
        currentVida -= damage;
        healthbar.SetHealth(currentVida);
        if (currentVida <= 0)
        {
            nino.GetComponent<Interaction>().contadorEnemigos--;
            Destroy(this.gameObject);
        }
    }
    
}
