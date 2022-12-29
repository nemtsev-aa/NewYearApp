using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Share : MonoBehaviour
{
    public GameObject ScreenShotCanvas;

    public void ClickShare()
    {
        ScreenShotCanvas.SetActive(false);
        
        StartCoroutine(TakeSSAndShare());
       
        ScreenShotCanvas.SetActive(true); 
    }

    private IEnumerator TakeSSAndShare()
    {
        yield return new WaitForEndOfFrame();
        Texture2D ss = new Texture2D(700, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect((Screen.width/2 - 350), 30, 700, Screen.height), 0, 0);
        ss.Apply();

        //Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        //ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        //ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        Destroy(ss);

        new NativeShare().AddFile(filePath).SetSubject("NewYear2023").SetText("My Tree").Share();
    }
}
