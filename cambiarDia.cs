using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarDia : MonoBehaviour
{

    public string text;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<TextEditor>().text = text;        
    }

}
