using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    //[SerializeField] MenuSelector menuSelector;
    [SerializeField] GameObject Cameras;
    [SerializeField] GameObject MenuConvas;
    [SerializeField] public TextMeshProUGUI CreatorText;

    private GameObject menuCanvas;
    private GameObject menuManager;

    private GameObject viewCanvas;
    private GameObject viewManager;

    private GameObject gameCanvas;
    private GameObject gameManager;

    public int appMode;
    private GameObject creatorName;

    // Update is called once per frame
    private void Awake()
    {
        menuCanvas = GameObject.Find("/Menu Convas/Menu");
        viewCanvas = GameObject.Find("/Menu Convas/View");
        viewManager = GameObject.Find("/Cameras/View");
        
        gameCanvas = GameObject.Find("/Menu Convas/Game");
        gameManager = GameObject.Find("/Cameras/Game");
        
    }

    private void Start()
    {
        appMode = 0;
        //SwitchingMode(appMode);
    }
    void Update()
    {
        
    }

    //public void SwitchingMode(int modeIndex)
    //{
    //    switch (modeIndex)
    //    {
    //        case 0:
    //            menuManager.SetActive(true);
    //            menuCanvas.SetActive(true);
    //            viewManager.SetActive(false);
    //            viewCanvas.SetActive(false);
    //            gameManager.SetActive(false);
    //            gameCanvas.SetActive(false);
    //            break;
    //        case 1:
    //            menuManager.SetActive(false);
    //            menuCanvas.SetActive(false);
    //            viewManager.SetActive(false);
    //            viewCanvas.SetActive(false);
    //            gameManager.SetActive(true);
    //            gameCanvas.SetActive(true);
    //            break;  
    //        case 2:
    //            menuManager.SetActive(false);
    //            menuCanvas.SetActive(false);
    //            viewManager.SetActive(true);
    //            viewCanvas.SetActive(true);
    //            gameManager.SetActive(false);
    //            gameCanvas.SetActive(false);
    //            break;
    //    }
    //}

    public void ShowName(string Name, bool status)
    {
        if (status == true)
        {
            CreatorText.text = Name;
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
