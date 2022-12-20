using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ButtonGameMenu;
    public GameObject ButtonGameExit;

    void Start()
    {
        //SceneManager.LoadScene("menuScene");
    }
           
    public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
