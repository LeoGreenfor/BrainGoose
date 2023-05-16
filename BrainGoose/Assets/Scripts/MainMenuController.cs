using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuController : MonoBehaviour
{    
    public void BeginGame()
    {
        SceneManager.LoadScene(Random.Range(1, 4));
    }
    public void Exit()
    {
        Application.Quit();
    }
}
