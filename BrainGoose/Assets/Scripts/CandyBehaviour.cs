using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CandyBehaviour : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int row;
    [SerializeField]
    private int collumn;

    [SerializeField]
    private CandyPlaceController controller;

    private Animator animator;

    public bool IsMatches = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Base Layer.Idle") && !IsMatches)
        {
            FindMatches();
            if (IsMatches)
            {
                Debug.Log("+5");
                AddScore(5);
                DestroyCandy();
            }
            IsMatches = false;
        } else if (stateInfo.IsName("Base Layer.CreateNewGameChip"))
        {
            animator.SetBool("isFindMatch", false);
            animator.SetBool("isWasDestroyed", false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (controller.IsFirstCandySelect)
        {
            controller.MakeStep(row, collumn);
            controller.IsFirstCandySelect = false;
        } else
        if (!controller.IsFirstCandySelect)
        {
            controller.currentCandyRow = row;
            controller.currentCandyCollumn = collumn;
            controller.IsFirstCandySelect = true;
        }
    }

    public void DestroyCandy()
    {
        animator.SetBool("isFindMatch", true);
        StartCoroutine(Culldown());
    }

    private IEnumerator Culldown()
    {
        yield return new WaitForSeconds(1.2f);
        animator.SetBool("isWasDestroyed", true);
        yield return new WaitForSeconds(0.1f);
        controller.SetRandomCandy(row, collumn);
    }

    private void FindMatches()
    {
        if (collumn > 0 && collumn < controller.numberOfColumns - 1)
        {
            Image leftCandy1 = controller.candyImagesOnGrid[row, collumn - 1];
            Image rightCandy1 = controller.candyImagesOnGrid[row, collumn + 1];

            if (leftCandy1.sprite == this.GetComponent<Image>().sprite 
                && rightCandy1.sprite == this.GetComponent<Image>().sprite)
            {
                //AddScore(5);
                //Debug.Log($"find matches at {row}, {collumn} && {row}, {collumn - 1} {row}, {collumn + 1}");
                /*leftCandy1.GetComponent<CandyBehaviour>().DestroyCandy();
                rightCandy1.GetComponent<CandyBehaviour>().DestroyCandy();
                this.gameObject.GetComponent<CandyBehaviour>().DestroyCandy();*/

                leftCandy1.GetComponent<CandyBehaviour>().IsMatches = true;
                rightCandy1.GetComponent<CandyBehaviour>().IsMatches = true;
                IsMatches = true;
            }
        }

        if (row > 0 && row < controller.numberOfRows - 1)
        {
            Image upCandy1 = controller.candyImagesOnGrid[row - 1, collumn];
            Image downCandy1 = controller.candyImagesOnGrid[row + 1, collumn];

            if (upCandy1.sprite == this.GetComponent<Image>().sprite
                && downCandy1.sprite == this.GetComponent<Image>().sprite)
            {
                //AddScore(5);
                //Debug.Log($"find matches at {row}, {collumn} && {row - 1}, {collumn} {row + 1}, {collumn}");
                
                /*upCandy1.GetComponent<CandyBehaviour>().DestroyCandy();
                downCandy1.GetComponent<CandyBehaviour>().DestroyCandy();
                this.gameObject.GetComponent<CandyBehaviour>().DestroyCandy();*/

                upCandy1.GetComponent<CandyBehaviour>().IsMatches = true;
                downCandy1.GetComponent<CandyBehaviour>().IsMatches = true;
                IsMatches = true;
            }
        }
    }
    private void AddScore(int score)
    {
        if (IsMatches)
        {
            score += int.Parse(controller.scoreText.text);
            controller.scoreText.text = score.ToString();
        }
    }
}
