using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //We'll be using a function called LoadScene from the SceneManager class


public class ChangeScene : MonoBehaviour
{
    public void MoveToScene(int sceneID) //Loading the scene ID where we want to move to
    {
        SceneManager.LoadScene(sceneID);
    }
    
    //Called when the user clicks the quit button
    public void Quit()
    {
        Application.Quit();
    }
}
