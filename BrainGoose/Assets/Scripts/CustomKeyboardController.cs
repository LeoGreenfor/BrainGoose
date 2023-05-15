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
        // Отримуємо всі Стрічки від Канвасу
        Transform[] strips = GetComponentsInChildren<Transform>().Where(obj => obj.CompareTag("Row")).ToArray();

        // Проходимося по кожній Стрічці і отримуємо всі Клавіші
        foreach (Transform strip in strips)
        {
            Button[] buttons = strip.GetComponentsInChildren<Button>();

            // Проходимося по кожній Клавіші
            foreach (Button button in buttons)
            {
                // Додаємо обробник події натискання на Клавішу
                button.onClick.AddListener(() =>
                {
                    button.interactable = false;
                });
            }
        }
    }
}
