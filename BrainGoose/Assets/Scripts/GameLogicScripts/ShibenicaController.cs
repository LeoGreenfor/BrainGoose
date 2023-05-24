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
        ListOfWordsAndTopic[0] = "Животные_гусь_В воде плавает, по земле ходит.";
        ListOfWordsAndTopic[1] = "Животные_дельфин_Играется в волнах, умело ловит рыбу.";
        ListOfWordsAndTopic[2] = "Животные_жираф_Длинная шея, высокая статура.";
        ListOfWordsAndTopic[3] = "Животные_креветка_В море крошечная, но очень вкусная.";
        ListOfWordsAndTopic[4] = "Животные_осьминог_Много рук, скрытая хитрость.";
        ListOfWordsAndTopic[5] = "Животные_носорог_Рогатый гигант, наделенный силой.";

        ListOfWordsAndTopic[6] = "Растения_ромашка_В лугах белеет, лепестки считает.";
        ListOfWordsAndTopic[7] = "Растения_тюльпан_Весной встает, красотой сияет.";
        ListOfWordsAndTopic[8] = "Растения_одуванчик_Ветром разносится, детьми собирается.";
        ListOfWordsAndTopic[9] = "Растения_хризантема_В осенних садах, цветет во всей красе.";
        ListOfWordsAndTopic[10] = "Растения_василёк_В полевых просторах, голубеет в траве.";
        ListOfWordsAndTopic[11] = "Растения_роза_Королева сада, шипы свои имеет.";

        ListOfWordsAndTopic[12] = "Профессии_библиотекарь_Страницы сторожит и знанием вдохновляет.";
        ListOfWordsAndTopic[13] = "Профессии_програмист_Виртуальные миры творит виртуозным кодом. ";
        ListOfWordsAndTopic[14] = "Профессии_учитель_Знания дарит и умом наполняет.";
        ListOfWordsAndTopic[15] = "Профессии_солдат_Защищает родину и святую землю.";
        ListOfWordsAndTopic[16] = "Профессии_водитель_На дорогах и трассах уверенно ведет.";
        ListOfWordsAndTopic[17] = "Профессии_строитель_Здания воздвигает, мир преображает.";

        ListOfWordsAndTopic[18] = "Элементы_вода_Жизнь без нее безлика, реки и озера полны ею.";
        ListOfWordsAndTopic[19] = "Элементы_огонь_Без него жизнь немыслима, искрится и блещет.";
        ListOfWordsAndTopic[20] = "Элементы_земля_Где растут цветы и травы, в нее корни погружены.";
        ListOfWordsAndTopic[21] = "Элементы_воздух_Невидим, но всюду присутен, взмахнет крылами и понесется ввысь.";
        ListOfWordsAndTopic[22] = "Элементы_хаос_Безразмерен и неуловим, хаосом мир наполняет.";
        ListOfWordsAndTopic[23] = "Элементы_порядок_Все по своим местам расставляет.";
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

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
