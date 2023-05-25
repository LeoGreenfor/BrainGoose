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
            score.text = "Очки: " + SaveManager.GetScore().ToString();
        }
        //SaveManager.CheckScore();
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

    public void NextScene()
    {
        SceneManager.LoadScene(Random.Range(2, 4));
    }

    public void Loadscene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
