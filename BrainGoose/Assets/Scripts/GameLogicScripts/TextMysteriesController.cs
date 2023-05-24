using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.UI;
using GameSaver;
using UnityEngine.SceneManagement;

public class TextMysteriesController : MonoBehaviour
{
    // Start is called before the first frame update
    string[] mysteries = { "Пишет он, когда диктуют,\r\nОн и чертит, и рисует,\r\nА сегодня вечерком\r\nОн раскрасит мне альбом.",
                           "Что с пола за хвост не поднимешь?",
                           "Я весь из железа,\r\nА в щелку залезу….\r\nТы в дом ни за что\r\nНе войдешь без меня.",
                           "Летом – спит,\r\nЗимой – горит,\r\nПасть открывает,\r\nЧто дают – глотает.",
                           "Что всегда идет,\r\nА с места не сойдет?",
                           "Четыре братца\r\nПод одной крышей стоят.",
                           "Сами не едим,\r\nА людей кормим.",
                           "Я над речкой лежу,\r\nОба берега держу.",
                           "Идут ко мне унылые,\r\nС морщинками, со складками,\r\nУходят очень милыми,\r\nВеселыми и гладкими.",
                           "И в тайге, и в океане\r\nОн отыщет путь любой,\r\nУмещается в кармане,\r\nА ведет нас за собой.",
                           "Все меня топчут, а я — всё лучше.",
                           "Что невозможно удержать и десяти минут, хотя оно легче пёрышка?",
                           "Что можно увидеть с закрытыми глазами?",
                           "Назови ее по имени и она исчезнет",
                           "Сколько лет в году?",
                           "Чем можно поделиться только один раз?",
                           "Какой остров сам себя называет предметом белья?",
                           "День и ночь стучит оно,\r\nСловно бы заведено.\r\nБудет плохо, если вдруг\r\nПрекратится этот стук.",
                           "Чудо фабрика у нас,\r\nОчищает кровь за час.\r\nЯды все она съедает,\r\nК сердцу их не подпускает."};
    string[] allAnswers = {"Карандаш Ручка Фломастер Кисточка",
                        "Клубок Кот Катушка Кабель", 
                        "Ключ Молоток Лом Гвоздодёр",
                        "Печь Медведь Дрова Газ",
                        "Часы Время Годы Дождь",
                        "Стол Стул Дом Сезоны",
                        "Ложки Вилки Руки Деньги",
                        "Мост Переход Переправа Дамба",
                        "Утюг Фитнес Спортзал Косметолог",
                        "Компас ГлоНаСС Интернет Телефон",
                        "Тропинка Дорога Ковёр Масло", 
                        "Дыхание Пух Вода Смех",
                        "Сон Тьма Ничего Звёзды",
                        "Тишина Песня Девушка Уверенность",
                        "Одно Один Одна Одни",
                        "Секретом Тайной Радостью Новостью",
                        "Ямайка Пасха Гоа Фиджи",
                        "Сердце Часы Сосед Молоток",
                        "Печень Почки Желудок Лимфа"};

    [SerializeField] private TMP_Text mysteryText;
    [SerializeField] private TMP_Text answer1;
    [SerializeField] private TMP_Text answer2;
    [SerializeField] private TMP_Text answer3;
    [SerializeField] private TMP_Text answer4;
    [SerializeField] private Image endGameScreen;

    string rightAnswer;
    int winCounter = 0;
    int loseCounter = 0;
    private int score = 500;

    private PlayerOriginator originator;
    private PlayerCaretaker caretaker;

    void Start()
    {
        InitiateGame();
        InitiateButtons();
    }

    private void InitiateGame()
    {
        int index = UnityEngine.Random.Range(0, mysteries.Length);
        mysteryText.text = mysteries[index];
        string answer = allAnswers[index];
        string[] answers = answer.Split(' ');
        string[] strings = new string[4];
        answer1.text = answers[UnityEngine.Random.Range(0, answers.Length)];
        strings[0] = answer1.text;
        rightAnswer = answers[0];
        do
        {
            answer2.text = answers[UnityEngine.Random.Range(0, answers.Length)];
        }
        while (strings.Contains(answer2.text));
        strings[1] = answer2.text;
        do
        {
            answer3.text = answers[UnityEngine.Random.Range(0, answers.Length)];
        }
        while (strings.Contains(answer3.text));
        strings[3] = answer3.text;
        do
        {
            answer4.text = answers[UnityEngine.Random.Range(0, answers.Length)];
        }
        while (strings.Contains(answer4.text));
        Button[] buttons = GetComponentsInChildren<Button>().ToArray();
        foreach (var item in buttons)
        {
            item.interactable = true;
            item.image.color = Color.white;
        }
    }
    private IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(5.0f);
        InitiateGame();
    }
    private void InitiateButtons()
    {
        Button[] buttons = GetComponentsInChildren<Button>().ToArray();
        // Проходимося по кожній Клавіші 
        foreach (Button button in buttons)
        {
            // Додаємо обробник події натискання на Клавішу 
            button.onClick.AddListener(() => {
                TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();
                if (buttonText.text == rightAnswer)
                {
                    button.image.color = Color.green;
                    winCounter++;
                    if (winCounter == 3)
                    {
                        StartCoroutine(Nextscene());
                    }
                    foreach (var item in buttons)
                    {
                        item.interactable = false;
                    }   
                    StartCoroutine(MyCoroutine());
                    
                }
                else
                {
                    button.image.color = Color.red;
                    if (loseCounter < 2)
                    {
                        score -= 50 + loseCounter * 25;
                    }
                    else
                    {
                        score -= 75 + loseCounter * 25;
                    }
                    loseCounter++;
                    button.interactable = false;
                    if (loseCounter == 3)
                    {
                        InitiateGame();
                        loseCounter = 0;
                    }
                    if(score <= 0)
                    {
                        score = 0;
                        StartCoroutine(Nextscene());
                    }
                }
            });
            
        }
        
    }

    private IEnumerator Nextscene()
    {
        SaveManager.AddScore(score);
        SaveManager.SaveData();
        endGameScreen.GetComponentInChildren<TMP_Text>().text += SaveManager.GetScore().ToString();
        endGameScreen.gameObject.SetActive(true);

        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene(UnityEngine.Random.Range(2, 4));
    }
}
