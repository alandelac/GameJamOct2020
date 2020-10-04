using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Square : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject square1;
    public GameObject square2;
    public GameObject square3;
    public string bala;


    void Start()
    {

        square1.SetActive(false);
        square2.SetActive(false);
        square3.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            square1.SetActive(true);
            square2.SetActive(false);
            square3.SetActive(false);
            bala = "Slingshot";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            square1.SetActive(false);
            square2.SetActive(true);
            square3.SetActive(false);
            bala = "Pistola";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            square1.SetActive(false);
            square2.SetActive(false);
            square3.SetActive(true);
            bala = "Staff";
        }
     
        


    }
}
