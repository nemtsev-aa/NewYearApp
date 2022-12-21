using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
public class GameManager : MonoBehaviour
{
    //[SerializeField] MenuSelector menuSelector;
    [SerializeField] GameObject Cameras;
    [SerializeField] GameObject MenuConvas;
    [SerializeField] public TextMeshProUGUI CreatorText;

    private GameObject[] Manager = new GameObject[0];
    private GameObject[] Canvas = new GameObject[0];

    [Range(0, 2)]
    public int appMode;

    // Update is called once per frame
    private void Awake()
    {
        int i = 0;

        //Array to hold all child obj
        Manager = new GameObject[Cameras.transform.childCount];
        Canvas = new GameObject[MenuConvas.transform.childCount];

        //Find all child obj and store to that array
        foreach (Transform child in Cameras.transform)
        {
            Manager[i] = child.gameObject;
            i += 1;
        }

        i = 0;
        foreach (Transform child in MenuConvas.transform)
        {
            Canvas[i] = child.gameObject;
            i += 1;
        }
    }

    private void Start()
    {
        SwitchingMode(0);
    }
    private void Update()
    {
        SwitchingMode(appMode);
    }

    public void SwitchingMode(int modeIndex)
    {
        appMode = modeIndex;

        for (int i = 0; i < Cameras.transform.childCount; i++)
        {
            if (i == modeIndex)
            {
                Canvas[i].SetActive(true);
                Manager[i].SetActive(true);
            }
            else
            {
                Canvas[i].SetActive(false);
                Manager[i].SetActive(false);
            }
        }
    }

    public void ShowName(string Name, bool status)
    {
        if (status == true)
        {
            CreatorText.text = Name;
        }  
    }

    public void StartVoting(int variant)
    {
        if (variant == 1)
        {
            Application.OpenURL("https://vk.com/club209176624");
        }
        else if (variant == 2)
        {
            Application.OpenURL("");
        }
        
    }

    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
		Application.Quit();
        #endif
    }
}
