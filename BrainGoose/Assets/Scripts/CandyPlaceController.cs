using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CandyPlaceController : MonoBehaviour
{
    private string levelTag;

    public int currentCandyRow;
    public int currentCandyCollumn;
    public bool IsFirstCandySelect;

    [SerializeField]
    private Sprite[] candyImages;
    [SerializeField]
    private Image[] listOfCandyImages;
    [SerializeField]
    public int numberOfRows;
    [SerializeField]
    public int numberOfColumns;

    public Image[,] candyImagesOnGrid;

    public TMP_Text scoreText;

    private void Start()
    {
        levelTag = this.gameObject.tag;
        IsFirstCandySelect = false;
        candyImagesOnGrid = new Image[numberOfRows, numberOfColumns];
        PlaceCandies();

        int k = 0;
        if (levelTag == "Canvas")
        {
            for (int i = 0; i < numberOfRows; i++)
                for (int j = 0; j < numberOfColumns; j++)
                {
                    candyImagesOnGrid[i, j] = listOfCandyImages[k];
                    k++;
                }
        } else
        {
            for (int i = 0; i < numberOfRows; i++)
                for (int j = 0; j < numberOfColumns; j++)
                {
                        candyImagesOnGrid[i, j] = listOfCandyImages[k];
                    k++;
                }
        }
    }

    public void PlaceCandies()
    {
        for (int i = 0; i < listOfCandyImages.Length; i++)
        {
            listOfCandyImages[i].sprite = GetRandomCandy();
        }
    }

    public void MakeStep(int row, int collumn)
    {
        bool inOneRow = currentCandyRow == row;
        bool inOneCol = currentCandyCollumn == collumn;
        bool onRowNear = (currentCandyRow + 1 == row) || (currentCandyRow - 1 == row);
        bool onColNear = (currentCandyCollumn + 1 == collumn) || (currentCandyCollumn - 1 == collumn);
        
        if (inOneRow)
        {
            if (onColNear)
            {
                Sprite temp = candyImagesOnGrid[currentCandyRow, currentCandyCollumn].sprite;
                candyImagesOnGrid[currentCandyRow, currentCandyCollumn].sprite = candyImagesOnGrid[row, collumn].sprite;
                candyImagesOnGrid[row, collumn].sprite = temp;
            }
        }
        else if (inOneCol)
        {
            if (onRowNear)
            {
                Sprite temp = candyImagesOnGrid[currentCandyRow, currentCandyCollumn].sprite;
                candyImagesOnGrid[currentCandyRow, currentCandyCollumn].sprite = candyImagesOnGrid[row, collumn].sprite;
                candyImagesOnGrid[row, collumn].sprite = temp;
            }
        }

        IsFirstCandySelect = false;

    }

    private Sprite GetRandomCandy()
    {
        return candyImages[Random.Range(0, candyImages.Length - 1)];
    }

    public void SetRandomCandy(int row, int collumn)
    {
        candyImagesOnGrid[row, collumn].sprite = GetRandomCandy();
    }


}
