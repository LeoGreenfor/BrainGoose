using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject qObject;

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SeeQ()
    {
        qObject.SetActive(true);
    }
    public void HideQ()
    {
        qObject.SetActive(false);
    }

    public void GoByUrl(string url)
    {
        Application.OpenURL(url);
    }

    public void NextScene()
    {
        int index = Random.Range(2, 5);
        while (index == SceneManager.GetActiveScene().buildIndex)
        {
            index = Random.Range(2, 5);
        }
        SceneManager.LoadScene(index);
        //SceneManager.LoadScene(Random.Range(2, 5));
    }
}
