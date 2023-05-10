using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.UI;

public class TextMysteriesController : MonoBehaviour
{
    // Start is called before the first frame update
    string[] mysteries = { "����� ��, ����� �������,\r\n�� � ������, � ������,\r\n� ������� ��������\r\n�� ��������� ��� ������.",
                           "��� � ���� �� ����� �� ���������?",
                           "� ���� �� ������,\r\n� � ����� ������.\r\n�� � ��� �� �� ���\r\n�� ������� ��� ����.",
                           "����� � ����,\r\n����� � �����,\r\n����� ���������,\r\n��� ���� � �������.",
                           "��� ������ ����,\r\n� � ����� �� ������?",
                           "������ ������\r\n��� ����� ������ �����.",
                           "���� �� ����,\r\n� ����� ������.",
                           "� ��� ������ ����,\r\n��� ������ �����.",
                           "���� �� ��� ������,\r\n� ����������, �� ���������,\r\n������ ����� ������,\r\n�������� � ��������.",
                           "� � �����, � � ������\r\n�� ������ ���� �����,\r\n��������� � �������,\r\n� ����� ��� �� �����."};

    string[] allAnswers = {"�������� ����� ��������� ��������",
                        "������ ��� ������� ������", 
                        "���� ������� ��� ��������",
                        "���� ������� ����� ���",
                        "���� ����� ���� �����",
                        "���� ���� ��� ������",
                        "����� ����� ���� ������",
                        "���� ������� ��������� �����",
                        "���� ������ �������� ����������",
                        "������ ������� �������� �������"};

    [SerializeField] private TMP_Text mysteryText;
    [SerializeField] private TMP_Text answer1;
    [SerializeField] private TMP_Text answer2;
    [SerializeField] private TMP_Text answer3;
    [SerializeField] private TMP_Text answer4;

    [SerializeField] private TMP_Text answer5;
    string rightAnswer;
    void Start()
    {
        Initiate();
    }

    private void Initiate()
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
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        // �������� �� ������ �� ������� 
        Button[] buttons = GetComponentsInChildren<Button>().ToArray();
        
        // ����������� �� ����� ������ 
        foreach (Button button in buttons)
        {
            // ������ �������� ��䳿 ���������� �� ������ 
            button.onClick.AddListener(() => {
                TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();
                if (buttonText.text == rightAnswer)
                {
                    button.image.color = Color.green;
                }
                else
                {
                    button.image.color = Color.red;
                }
            });
            
        }
        
    }
}
