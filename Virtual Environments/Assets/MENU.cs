using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENU : MonoBehaviour
{
    public void changeScene(){
        SceneManager.LoadScene(1);
    }

    public void exit(){
        Application.Quit();
    }
}
