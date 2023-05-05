using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShibenicaController : MonoBehaviour
{
    #region UI
    [SerializeField]
    private TMP_Text TopicText;
    [SerializeField]
    private TMP_Text WordText;
    #endregion
    #region Word
    private string[] ListOfWordsAndTopic = new string[4];
    private string currentWord;
    private string emptyWord = "";
    private int currentTopic;
    #endregion

    void Start()
    {
        CreateListOfWords();
        currentTopic = Random.Range(0, 3);
        string[] substrings = ListOfWordsAndTopic[currentTopic].Split(" ");
        currentWord = substrings[1];
        
        for (int i = 0; i < currentWord.Length; i++)
        {
            emptyWord += "_";
        }

        TopicText.text = substrings[0];
        WordText.text = substrings[1];
    }

    void Update()
    {
        
    }

    private void CreateListOfWords()
    {
        ListOfWordsAndTopic[0] = "Animal Goose";
        //ListOfWordsAndTopic[0] = "Goose";

        ListOfWordsAndTopic[1] = "Plant Dandelion";
        //ListOfWordsAndTopic[1] = "Dandelion";

        ListOfWordsAndTopic[2] = "Jobs Librarian";
        //ListOfWordsAndTopic[2] = "Librarian";

        ListOfWordsAndTopic[3] = "Elements Water";
        //ListOfWordsAndTopic[3] = "Water";
    }
}
