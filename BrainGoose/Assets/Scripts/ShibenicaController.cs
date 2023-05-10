using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShibenicaController : MonoBehaviour
{
    #region UI
    [SerializeField]
    private TMP_Text TopicText;
    [SerializeField]
    private TMP_Text WordText;
    [SerializeField]
    private Image shibenicaImage;
    [SerializeField]
    private Image endGameScreen;
    #endregion
    #region Word
    private string[] ListOfWordsAndTopic = new string[24];
    private string currentWord;
    private string rightWord;
    private string emptyWord = "";
    private int currentTopic;
    #endregion
    #region Logic
    private bool IsLetterOnClick = false;
    private char currentLetter;
    private int numberOfMistakes = 0;
    #endregion

    void Start()
    {
        CreateListOfWords();
        currentTopic = Random.Range(0, 23);
        string[] substrings = ListOfWordsAndTopic[currentTopic].Split(" ");
        currentWord = substrings[1];
        rightWord = currentWord;
        
        for (int i = 0; i < currentWord.Length; i++)
        {
            emptyWord += "_";
        }

        TopicText.text = substrings[0];
        WordText.text = emptyWord;
    }

    void Update()
    {
        bool isWinningGame = false;
        if (IsLetterOnClick)
        {
            if (currentWord.Contains(currentLetter))
            {
                while (currentWord.Contains(currentLetter))
                {
                    int index = currentWord.IndexOf(currentLetter);
                    char[] emptyWordArr = emptyWord.ToCharArray();
                    char[] currentWordArr = currentWord.ToCharArray();

                    emptyWordArr[index] = currentLetter;
                    currentWordArr[index] = '_';

                    emptyWord = new string(emptyWordArr);
                    currentWord = new string(currentWordArr);

                    WordText.text = emptyWord;
                }
                if (emptyWord == rightWord)
                {
                    isWinningGame = true;
                }
            }
            else
            {
                numberOfMistakes++;
                shibenicaImage.GetComponent<ImageInfo>().ChangeImage(numberOfMistakes);
            }
            
            IsLetterOnClick = false;
        }

        if (numberOfMistakes == 4)
        {
            endGameScreen.gameObject.SetActive(true);
            endGameScreen.color = new Color(205.0f, 0.0f, 0.0f, 0.5f);
        }
        if (isWinningGame)
        {
            endGameScreen.gameObject.SetActive(true);
            endGameScreen.color = new Color(0.0f, 200.0f, 0.0f, 0.5f);
        }
    }

    private void CreateListOfWords()
    {
        ListOfWordsAndTopic[0] = "Животные гусь";
        ListOfWordsAndTopic[1] = "Животные дельфин";
        ListOfWordsAndTopic[2] = "Животные жираф";
        ListOfWordsAndTopic[3] = "Животные креветка";
        ListOfWordsAndTopic[4] = "Животные осьминог";
        ListOfWordsAndTopic[5] = "Животные носорог";

        ListOfWordsAndTopic[6] = "Растения ромашка";
        ListOfWordsAndTopic[7] = "Растения тюльпан";
        ListOfWordsAndTopic[8] = "Растения одуванчик";
        ListOfWordsAndTopic[9] = "Растения хризантема";
        ListOfWordsAndTopic[10] = "Растения василёк";
        ListOfWordsAndTopic[11] = "Растения роза";

        ListOfWordsAndTopic[12] = "Профессии библиотекарь";
        ListOfWordsAndTopic[13] = "Профессии програмист";
        ListOfWordsAndTopic[14] = "Профессии учитель";
        ListOfWordsAndTopic[15] = "Профессии солдат";
        ListOfWordsAndTopic[16] = "Профессии водитель";
        ListOfWordsAndTopic[17] = "Профессии строитель";

        ListOfWordsAndTopic[18] = "Элементы вода";
        ListOfWordsAndTopic[19] = "Элементы огонь";
        ListOfWordsAndTopic[20] = "Элементы земля";
        ListOfWordsAndTopic[21] = "Элементы воздух";
        ListOfWordsAndTopic[22] = "Элементы хаос";
        ListOfWordsAndTopic[23] = "Элементы порядок";
    }

    public void SetIsLetterOnClick(bool isClick)
    {
        IsLetterOnClick = isClick;
    }
    public void SetCurrentLetter(char letter)
    {
        currentLetter = letter;
    }

}
