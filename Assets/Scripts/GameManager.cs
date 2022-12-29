using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[ExecuteInEditMode]
public class GameManager : MonoBehaviour
{
    //[SerializeField] MenuSelector menuSelector;
    [SerializeField] GameObject room;
    [SerializeField] GameObject cameras;
    [SerializeField] GameObject menuConvas;
    [SerializeField] GameObject audioObject;
    [SerializeField] GameObject soundToggle;

    [SerializeField] public TextMeshProUGUI creatorText;
    [SerializeField] public TextMeshProUGUI selectionToyIndex;
    
    [Header("Музыка")]
    [SerializeField] public bool sound;

    public List<GameObject> createToyList;

    private GameObject[] Tree = new GameObject[0];
    private GameObject[] Manager = new GameObject[0];
    private GameObject[] Canvas = new GameObject[0];
    

    [Range(0, 3)]
    public int appMode;

    private GameObject toysContent;
    private AudioManager audioManager;
    private GameObject OnOffText;

    // Update is called once per frame
    private void Awake()
    {
        

        int i = 0;

        //Array to hold all child obj
        Tree = new GameObject[room.transform.childCount];
        Manager = new GameObject[cameras.transform.childCount];
        Canvas = new GameObject[menuConvas.transform.childCount];
        
        
        //Find all child obj and store to that array
        foreach (Transform child in room.transform)
        {
            Tree[i] = child.gameObject;
            i += 1;
        }

        i = 0;
        foreach (Transform child in cameras.transform)
        {
            Manager[i] = child.gameObject;
            i += 1;
        }

        i = 0;
        foreach (Transform child in menuConvas.transform)
        {
            Canvas[i] = child.gameObject;
            i += 1;
        }

        audioManager = audioObject.GetComponent<AudioManager>();
    }

    private void Start()
    {
        SwitchingMode(0);
        audioManager.SoundOn(0);
    }

    private void Update()
    {
        SwitchingMode(appMode);
        audioObject.SetActive(sound);
    }

    public void SwitchingMode(int modeIndex)
    {
        appMode = modeIndex;

        for (int i = 0; i < cameras.transform.childCount; i++)
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

        if (modeIndex==1 || modeIndex == 3)
        {
            Tree[0].SetActive(true);
            Tree[1].SetActive(false); 
        }
        else
        {
            Tree[0].SetActive(false);
            Tree[1].SetActive(true);

            if (appMode == 0)
            {
                Tree[1].transform.position = new Vector3(0, 0, 0);
            }
        }

        if (modeIndex == 0)
        {
            Tree[2].SetActive(true);
        }
        else
        {
            Tree[2].SetActive(false);
        }

    }

    public void ShowName(string Name, bool status)
    {
        if (status == true)
        {
            creatorText.text = Name;
        }
    }
    
    public void ShowIndex(int index)
    {
       selectionToyIndex.text = index.ToString();
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
    public void ShowBullet(bool status)
    {
        foreach (GameObject item in createToyList)
        {
            item.gameObject.SetActive(status);
        }
    }

    public void DestroyAllBullet()
    {
        foreach (GameObject item in createToyList)
        {
            Destroy(item.gameObject);
        }

        createToyList.Clear();
    }

    public void AddToyToCollection(GameObject newToy)
    {
        createToyList.Add(newToy);
    }

    public void SoundOn()
    {
        sound = soundToggle.GetComponent<Toggle>().isOn; 
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
