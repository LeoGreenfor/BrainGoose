using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CustomKeyboardController : MonoBehaviour
{
    private ShibenicaController shibenicaController;


    private void Start()
    {
        shibenicaController = GameObject.FindGameObjectWithTag("Player").GetComponent<ShibenicaController>();
        
    }

    public void GetLetter(string letter)
    {
        char actuallyLetter = char.Parse(letter);
        shibenicaController.SetCurrentLetter(actuallyLetter);
        shibenicaController.SetIsLetterOnClick(true);
    }

    private void FixedUpdate()
    {
        // �������� �� ������ �� �������
        Transform[] strips = GetComponentsInChildren<Transform>().Where(obj => obj.CompareTag("Row")).ToArray();

        // ����������� �� ����� ������ � �������� �� ������
        foreach (Transform strip in strips)
        {
            Button[] buttons = strip.GetComponentsInChildren<Button>();

            // ����������� �� ����� ������
            foreach (Button button in buttons)
            {
                // ������ �������� ��䳿 ���������� �� ������
                button.onClick.AddListener(() =>
                {
                    button.interactable = false;
                });
            }
        }
    }
}
