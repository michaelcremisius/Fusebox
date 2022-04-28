using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class videoplayer_go : MonoBehaviour
{
    public GameObject vidtex;
    VideoPlayer videoPlayer;
    
    void Awake()
    {
        videoPlayer = vidtex.GetComponent<VideoPlayer>();
    }

    void Play()
    {
        videoPlayer.Play();
    }
}
