using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatGameScript : MonoBehaviour
{
    public string sceneName;
    
    public void PlayGame(string sceneGame)
    {
        SceneManager.LoadScene(sceneGame);
    }
   
}
