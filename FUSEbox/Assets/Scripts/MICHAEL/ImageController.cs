using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageController : MonoBehaviour
{
    private List<GameObject> pictures;
    private int index;
    // Start is called before the first frame update
    private void Start()
    {
        index = 0;
    }
    public void MoveRight()
    {
        pictures[index].SetActive(false);
        if(index + 1 <= pictures.Count - 1)
        {
            ++index;
        }
        else
        {
            index = 0;
        }
        pictures[index].SetActive(true);
    }
    public void MoveLeft()
    {
        pictures[index].SetActive(false);
        if (index - 1 > -1)
        {
            --index;
        }
        else
        {
            index = pictures.Count - 1;
        }
        pictures[index].SetActive(true);
    }
    public void AddImage(GameObject nextImage)
    {
        pictures.Add(nextImage);
    }
}

