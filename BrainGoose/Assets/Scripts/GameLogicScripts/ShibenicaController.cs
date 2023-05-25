using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameSaver;

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
    [SerializeField]
    private TMP_Text qText;
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
    private int maxPoints = 500;
    #endregion

    void Start()
    {
        CreateListOfWords();
        currentTopic = Random.Range(0, 23);
        string[] substrings = ListOfWordsAndTopic[currentTopic].Split("_");
        currentWord = substrings[1];
        rightWord = currentWord;
        qText.text = substrings[2];
        
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
                maxPoints -= 100;
            }
            
            IsLetterOnClick = false;
        }

        if (numberOfMistakes == 4)
        {
            numberOfMistakes = 0;
            endGameScreen.color = new Color(205.0f, 0.0f, 0.0f, 0.5f);
            StartCoroutine(Nextscene());
        }
        if (isWinningGame)
        {
            endGameScreen.color = new Color(0.0f, 200.0f, 0.0f, 0.5f);
            StartCoroutine(Nextscene());
        }
    }

    private void CreateListOfWords()
    {
        ListOfWordsAndTopic[0] = "��������_����_� ���� �������, �� ����� �����.";
        ListOfWordsAndTopic[1] = "��������_�������_�������� � ������, ����� ����� ����.";
        ListOfWordsAndTopic[2] = "��������_�����_������� ���, ������� �������.";
        ListOfWordsAndTopic[3] = "��������_��������_� ���� ���������, �� ����� �������.";
        ListOfWordsAndTopic[4] = "��������_��������_����� ���, ������� ��������.";
        ListOfWordsAndTopic[5] = "��������_�������_������� ������, ���������� �����.";

        ListOfWordsAndTopic[6] = "��������_�������_� ����� ������, �������� �������.";
        ListOfWordsAndTopic[7] = "��������_�������_������ ������, �������� �����.";
        ListOfWordsAndTopic[8] = "��������_���������_������ ����������, ������ ����������.";
        ListOfWordsAndTopic[9] = "��������_����������_� ������� �����, ������ �� ���� �����.";
        ListOfWordsAndTopic[10] = "��������_������_� ������� ���������, �������� � �����.";
        ListOfWordsAndTopic[11] = "��������_����_�������� ����, ���� ���� �����.";

        ListOfWordsAndTopic[12] = "���������_������������_�������� �������� � ������� �����������.";
        ListOfWordsAndTopic[13] = "���������_����������_����������� ���� ������ ���������� �����. ";
        ListOfWordsAndTopic[14] = "���������_�������_������ ����� � ���� ���������.";
        ListOfWordsAndTopic[15] = "���������_������_�������� ������ � ������ �����.";
        ListOfWordsAndTopic[16] = "���������_��������_�� ������� � ������� �������� �����.";
        ListOfWordsAndTopic[17] = "���������_���������_������ ����������, ��� �����������.";

        ListOfWordsAndTopic[18] = "��������_����_����� ��� ��� �������, ���� � ����� ����� ��.";
        ListOfWordsAndTopic[19] = "��������_�����_��� ���� ����� ���������, �������� � ������.";
        ListOfWordsAndTopic[20] = "��������_�����_��� ������ ����� � �����, � ��� ����� ���������.";
        ListOfWordsAndTopic[21] = "��������_������_�������, �� ����� ��������, �������� ������� � ��������� �����.";
        ListOfWordsAndTopic[22] = "��������_����_����������� � ��������, ������ ��� ���������.";
        ListOfWordsAndTopic[23] = "��������_�������_��� �� ����� ������ �����������.";
    }

    public void SetIsLetterOnClick(bool isClick)
    {
        IsLetterOnClick = isClick;
    }
    public void SetCurrentLetter(char letter)
    {
        currentLetter = letter;
    }

    private IEnumerator Nextscene()
    {
        SaveManager.AddScore(maxPoints);
        SaveManager.SaveData();
        endGameScreen.GetComponentInChildren<TMP_Text>().text += SaveManager.GetScore().ToString();
        endGameScreen.gameObject.SetActive(true);

        yield return new WaitForSeconds(2.0f);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(Random.Range(2, 5));
    }

}
