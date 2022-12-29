using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationSetter : MonoBehaviour
{
    public enum Orientation
    {
        Any,
        Portrait,
        PortraitFixed,
        Landscape,
        LandscapeFixed
    }


    public Orientation ScreenOrientation;

    public void OrientationSelect(string orientation)
    {
        switch (orientation)
        {
            case "Any":
                ScreenOrientation = Orientation.Any;
                break;
            case "Portrait":
                ScreenOrientation = Orientation.Portrait;
                break;
            case "Landscape":
                ScreenOrientation = Orientation.Landscape;
                break;
        }

        OrientationSetup();

    }

    public void OrientationSetup()
    {
        switch (ScreenOrientation)
        {
            case Orientation.Any:
                Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;

                Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = true;
                Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = true;
                break;

            case Orientation.Portrait:
                // Force screen to orient right, then switch to Auto
                Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
                Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;

                Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = true;
                Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = false;
                break;

            case Orientation.PortraitFixed:
                Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
                break;

            case Orientation.Landscape:
                // Force screen to orient right, then switch to Auto
                Screen.orientation = UnityEngine.ScreenOrientation.LandscapeLeft;
                Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;

                Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = false;
                Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = true;
                break;

            case Orientation.LandscapeFixed:
                Screen.orientation = UnityEngine.ScreenOrientation.LandscapeLeft;
                break;
        }

        Destroy(gameObject);
    }
}
