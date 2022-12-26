using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoCapture : MonoBehaviour
{
    public Camera captureCamera;
    public void MakeScrenshot()
    {
        ScreenCapture.CaptureScreenshot("Scene_" + System.DateTime.Now.Second.ToString() + ".png");
    }
}

