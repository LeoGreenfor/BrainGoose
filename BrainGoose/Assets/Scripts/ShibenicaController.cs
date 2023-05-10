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
                if (currentWord == emptyWord)
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
            endGameScreen.enabled = false;
            endGameScreen.color = new Color(205.0f, 0.0f, 0.0f, 145.0f);
        }
        if (isWinningGame)
        {
            endGameScreen.enabled = false;
            endGameScreen.color = new Color(0.0f, 200.0f, 0.0f, 145.0f);
        }
    }

    private void CreateListOfWords()
    {
        ListOfWordsAndTopic[0] = "�������� ����";
        ListOfWordsAndTopic[1] = "�������� �������";
        ListOfWordsAndTopic[2] = "�������� �����";
        ListOfWordsAndTopic[3] = "�������� ��������";
        ListOfWordsAndTopic[4] = "�������� ��������";
        ListOfWordsAndTopic[5] = "�������� �������";

        ListOfWordsAndTopic[6] = "�������� �������";
        ListOfWordsAndTopic[7] = "�������� �������";
        ListOfWordsAndTopic[8] = "�������� ���������";
        ListOfWordsAndTopic[9] = "�������� ����������";
        ListOfWordsAndTopic[10] = "�������� ������";
        ListOfWordsAndTopic[11] = "�������� ����";

        ListOfWordsAndTopic[12] = "��������� ������������";
        ListOfWordsAndTopic[13] = "��������� ����������";
        ListOfWordsAndTopic[14] = "��������� �������";
        ListOfWordsAndTopic[15] = "��������� ������";
        ListOfWordsAndTopic[16] = "��������� ��������";
        ListOfWordsAndTopic[17] = "��������� ���������";

        ListOfWordsAndTopic[18] = "�������� ����";
        ListOfWordsAndTopic[19] = "�������� �����";
        ListOfWordsAndTopic[20] = "�������� �����";
        ListOfWordsAndTopic[21] = "�������� ������";
        ListOfWordsAndTopic[22] = "�������� ����";
        ListOfWordsAndTopic[23] = "�������� �������";
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
