using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScannerBehaviour : MonoBehaviour
{
    //checks if the camera is currently available
    private bool camAvailable;
    //this is the information from the back camera
    private WebCamTexture backCam;
    //it defaults to this texture if the back camera is unavailable
    private Texture defaultBackground;
    [Tooltip("displays a texture2D UI element")]
    public RawImage background;
    [Tooltip("controls the aspect ratio manually")]
    public AspectRatioFitter fit;


    // Start is called before the first frame update
    void Start()
    {
        defaultBackground = background.texture;
        WebCamDevice[] cameras = WebCamTexture.devices;

        if(cameras.Length <= 0)
        {
            Debug.Log("NO CAMERAS");
            camAvailable = false;
            return;
        }

        for(int i = 0; i < cameras.Length; i++)
        {
            if(!cameras[i].isFrontFacing)
            {
                backCam = new WebCamTexture(cameras[i].name, Screen.width, Screen.height);
            }
        }
        if(backCam == null)
        {
            Debug.Log("NO CAMERAS");
            return;
        }

        backCam.Play();
        background.texture = backCam;

        camAvailable = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if there's nothing to update then just end
        if(!camAvailable)
        {
            return;
        }
        //set the aspect ratio to the camera's
        fit.aspectRatio = (float)backCam.width / (float)backCam.height;
        float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int oreintation = -backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0,0, oreintation);
    }
}
