using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlArmas : MonoBehaviour
{

    public float dano;
    public float tiempo;
    public float rapidez;
    AudioSource sound;

    Rigidbody2D rb;

    GameObject nino;

    Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        nino = GameObject.Find("nino");

        sound = GetComponent<AudioSource>();

        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement.x = 1f;
        }
        else //if(Input.GetKey(KeyCode.LeftArrow)==false && Input.GetKey(KeyCode.RightArrow) == false)
        {
            movement.x = 0f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            movement.y = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movement.y = -1f;
        }
        else
        {
            movement.y = 0f;
        }
        if (movement.x==0f && movement.y == 0f)
        {
            movement.y = -1f;
        }

        rb = this.gameObject.GetComponent<Rigidbody2D>();
        //Invoke("destruir", tiempo);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * rapidez * Time.fixedDeltaTime);
    }

    void destruir()
    {
      //  sound.Play();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemigo"))
        {
            collision.gameObject.GetComponent<ControlEnemigo>().takeDamage(dano);
            destruir();
        }
        else if (collision.gameObject.tag.Equals("Player") == false)
        {
            destruir();
        }
    }
}
