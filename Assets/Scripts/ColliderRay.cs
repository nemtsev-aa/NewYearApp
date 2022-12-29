using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum CreatorName { Иван, Артём, Софья, Вероника, Алёна, Елена, Юлия, Александр, Николай, Андрей, Кирилл, Анастасия, Владимир, Евгений, Илья, Захар, Григорий}

public class ColliderRay : MonoBehaviour
{
    //[SerializeField] GameObject viewManager;

    [SerializeField] GameObject viewManager;
    
    [SerializeField] CreatorName creatorName;
    
    private GameObject gameManager;
    private TextMeshProUGUI creatorText;
    private Camera viewCamera;
    private Outline outline;
    private int appMode;

    private void Awake()
    {
        //viewManager = GameObject.Find("/Cameras/View/View");
        viewCamera = viewManager.GetComponent<Camera>();
        gameManager = GameObject.Find("GameManager");
        creatorText = gameManager.GetComponent<GameManager>().creatorText;
        outline = transform.GetComponent<Outline>();

    }

    void Update()
    {
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        appMode = gameManager.GetComponent<GameManager>().appMode;
        
        if (appMode == 2)
        {
            if (GetComponent<Collider>().Raycast(ray, out hit, 100f))
            {
                creatorText.text = creatorName.ToString();

                outline.enabled = true;

                if (transform.localScale.x < 1f)
                {
                    transform.localScale = Vector3.one * 0.2f;
                }
                else
                {
                    transform.localScale = Vector3.one * 2f;
                }
            }
            else
            {
                outline.enabled = false;
                transform.localScale = Vector3.one * 1f;
            }
        } 
    }
}
