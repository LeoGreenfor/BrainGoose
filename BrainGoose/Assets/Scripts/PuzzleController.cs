using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour
{
    string[][] buttonTextCoor;
    // Start is called before the first frame update
    void Start()
    {
        Initiate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initiate()
    {
        Button[] buttons = GetComponentsInChildren<Button>().ToArray();
        string[] texts = new string[buttons.Length];

        for (int i = 0; i < buttons.Length; i++)
        {
            string temp = buttons[i].GetComponentInChildren<TMP_Text>().text;
            texts[i] = temp;
        }
        int n = texts.Length;
        
        while (n > 0)
        {
            n--;
            int k = Random.Range(0, n);
            (texts[n], texts[k]) = (texts[k], texts[n]);
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<TMP_Text>().text = texts[i];
        }

        GameObject[] rows = GetComponentsInChildren<GameObject>().Where(i => i.name.Contains("Row")).ToArray();
        buttonTextCoor = new string[rows.Length][];
        for (int i = 0; i < buttonTextCoor.Length; i++)
        {
            buttonTextCoor[i] = rows[i].GetComponentsInChildren<Button>().ToArray();
        }
    }
}
