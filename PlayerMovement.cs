using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Vector2 movement;
    public GameObject Varita;
    public GameObject Resortera;
    public GameObject Agua;
    public int arma=3;

    private void Start()
    {
        Invoke("disparar", 2f);
    }

    void disparar()
    {
        if (arma==3)
        {
            Instantiate(Varita, rb.position, Quaternion.identity);
            Invoke("disparar", Varita.GetComponent<controlArmas>().tiempo);
        }
        else if (arma == 2)
        {
            Instantiate(Agua, rb.position, Quaternion.identity);
            Invoke("disparar", Agua.GetComponent<controlArmas>().tiempo);
        }
        else if (arma == 1)
        {
            Instantiate(Resortera, rb.position, Quaternion.identity);
            Invoke("disparar", Resortera.GetComponent<controlArmas>().tiempo);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            arma = 1;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            arma = 2;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            arma = 3;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            movement.x = 1f;
        }
        else 
        {
            movement.x = 0f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement.y = 1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            movement.y = -1f;
        }
        else
        {
            movement.y = 0f;
        }
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);


    }

   
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
