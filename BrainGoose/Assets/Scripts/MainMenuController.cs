using GameSaver;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text score;

    private void Start()
    {
        SaveManager.LogIn();
        if (score != null)
        {
            score.text = "Очки: " + SaveManager.GetScore().ToString();
        }
    }

    public void BeginGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void GoByUrl(string url)
    {
        Application.OpenURL(url);
    }
}
