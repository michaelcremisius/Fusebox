using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageChildBehaviour : MonoBehaviour
{
    private ImageController imgctrl;
    private void Awake()
    {
        imgctrl = GameObject.Find("ImageControl").GetComponent<ImageController>();
        imgctrl.AddImage(gameObject);
        gameObject.SetActive(false);
    }
}
