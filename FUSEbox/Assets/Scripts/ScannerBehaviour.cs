using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ZXing;

public class ScannerBehaviour : MonoBehaviour
{


    [SerializeField]
    private RawImage RawImageBackground;
    [SerializeField]
    private AspectRatioFitter AspectRatioFilter;
    [SerializeField]
    private TextMeshProUGUI textOut;
    [SerializeField]
    private RectTransform scanZone;

    private bool isCanvasAvailable;
    private WebCamTexture CamTexture;

    // Start is called before the first frame update
    void Start()
    {
        SetUpCamera();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void SetUpCamera()
    {
        WebCamDevice[] devices = WebCamTexture.devices; // looks for cameras on devices and puts them into a list
        if(devices.Length == 0)//if there are no cameras end
        {
            isCanvasAvailable = false;
            return;
        }
        for(int i = 0; i < devices.Length; i++) //if there's a front facing camera set it to the current camera
        {
            if (devices[i].isFrontFacing == false)
            {
                CamTexture = new WebCamTexture(devices[i].name, (int)scanZone.rect.width, (int)scanZone.rect.height);
            }
            CamTexture.Play();
            RawImageBackground.texture = CamTexture;
            isCanvasAvailable = true;
        }
    }
}
