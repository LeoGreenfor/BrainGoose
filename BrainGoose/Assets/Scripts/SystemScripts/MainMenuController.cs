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
        ScreenManager.SetSceenOrientation();
        SaveManager.LoadPlayerScore();
        if (score != null)
        {
            score.text = "����: " + SaveManager.GetScore().ToString();
        }
    }

    public void BeginGame()
    {
        SaveManager.CheckScore();
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void Loadscene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
