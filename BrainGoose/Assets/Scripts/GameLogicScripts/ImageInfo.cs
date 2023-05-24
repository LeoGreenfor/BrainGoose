using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageInfo : MonoBehaviour
{
    [SerializeField]
    private Sprite[] images = new Sprite[5];

    public void ChangeImage(int index)
    {
        this.gameObject.GetComponent<Image>().sprite = images[index];
    }
}
