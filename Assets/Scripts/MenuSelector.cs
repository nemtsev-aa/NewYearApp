using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelector : MonoBehaviour
{
    [SerializeField] GameObject Menu;

    [SerializeField] GameObject ViewMode;

    [SerializeField] GameObject GameMode;

    public string mode;

    // Start is called before the first frame update
    void Awake()
    {
        Menu = GameObject.Find("MenuButtons");
        ViewMode = GameObject.Find("ViewModeButtons");
        GameMode = GameObject.Find("GameModeButtons");
       
    }
    private void Start()
    {
        MenuShow(true);
    }
    public void MenuShow(bool status)
    {
        Menu.SetActive(status);
        ViewModeShow(!status);
        GameModeShow(!status);
        mode = "Menu";

    }
    public void ViewModeShow(bool status)
    {
        ViewMode.SetActive(status);
        Menu.SetActive(!status);
        mode = "View";
    }
    public void GameModeShow(bool status)
    {
        GameMode.SetActive(status);
        Menu.SetActive(!status);
        mode = "Game";
    }

}
