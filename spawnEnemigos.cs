using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemigos : MonoBehaviour
{
    Vector2[] tumbas = new Vector2[9];
    public int contador;
    public GameObject calabaza;
    public GameObject enemigo2;
    public GameObject enemigo3;
    int lugar;

    public int contCalabazas;
    public int contEnemigo2;
    public int contEnemigo3;

    // Start is called before the first frame update
    void Start()
    {
        tumbas[0] = new Vector2(-1.46f, 2.15f);
        tumbas[1] = new Vector2(-14.5f, 11.58f);
        tumbas[2] = new Vector2(14.25f, 12.96f);
        tumbas[3] = new Vector2(13.57f, -7.09f);
        tumbas[4] = new Vector2(-16.11f, -9.24f);
        tumbas[5] = new Vector2(-4.63f, 18.62f);
        tumbas[6] = new Vector2(3.35f, 3.6f);
        tumbas[7] = new Vector2(6.95f, 15.1f);
        tumbas[8] = new Vector2(-1.6f, -15.4f);

        contador = contCalabazas + contEnemigo2 + contEnemigo3;

        Invoke("spamea",0f);
    }

   

    void spamea()
    {
        lugar = Random.Range(0, 8);
        if (contCalabazas > 0)
        {
            Instantiate(calabaza, tumbas[lugar], Quaternion.identity);
            contador--;
            contCalabazas--;
        }

        lugar = Random.Range(0, 8);
        if (contEnemigo2 > 0)
        {
            Instantiate(enemigo2, tumbas[lugar], Quaternion.identity);
            contador--;
            contEnemigo2--;
        }

        lugar = Random.Range(0, 8);
        if (contEnemigo3 > 0)
        {
            Instantiate(enemigo3, tumbas[lugar], Quaternion.identity);
            contador--;
            contEnemigo3--;
        }

        if (contador <= 0)
        {
            
        }
        else
        {
            Invoke("spamea", 5f);
        }


    }
}
