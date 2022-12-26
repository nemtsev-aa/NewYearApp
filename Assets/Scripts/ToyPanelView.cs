using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToyPanelView : MonoBehaviour
{ 
	[SerializeField] GameObject ToysContent;
	[SerializeField] GameObject BulletCreator;
	
	private GameObject[] ToysPanels = new GameObject[0];
	public GameObject[] ToysPanelsImage = new GameObject[0];
	//public GameObject[] ToysPanelsPrefabs = new GameObject[0];
	public GameObject[] BulletPrefabs;

	private Weapon weapon;

	private Color defaultColor;

	private void Awake()
	{
		//Array to hold all child obj
		int ToysContentCount = ToysContent.transform.childCount;
		ToysPanels = new GameObject[ToysContentCount];
		ToysPanelsImage = new GameObject[ToysContentCount];
		//ToysPanelsPrefabs = new GameObject[ToysContentCount];
		BulletPrefabs = BulletCreator.GetComponent<Weapon>().BulletPrefabs;

		for (int i = 0; i < ToysContentCount; i++)
        {
			GameObject child = ToysContent.transform.GetChild(i).gameObject;
			ToysPanels[i] = child;
			
            for (int index = 0; index  < child.transform.childCount; index ++)
            {
				GameObject childObj = child.transform.GetChild(index).gameObject;
				Debug.Log(childObj.name);

				string s1 = childObj.name;
				string ch;
				int indexOfChar;

				switch (index)
                {
					case 0:
						ch = "Backgroung";
						indexOfChar = s1.IndexOf(ch);
						Debug.Log(indexOfChar);
						if (indexOfChar == 0)
						{
							ToysPanelsImage[i] = childObj;
							defaultColor = childObj.GetComponent<Image>().color;
							continue;
						}
						break;
					case 2:
						ch = "MenuJoy";
						indexOfChar = s1.IndexOf(ch);
						Debug.Log(indexOfChar);
						if (indexOfChar == 0)
						{
							//ToysPanelsPrefabs[i] = childObj;
							continue;
						}
						break;
				}
            }
        }
		Debug.Log("ToysPanelsImage " + ToysPanelsImage.Length);
		//Debug.Log("ToysPanelsPrefabs " + ToysPanelsPrefabs.Length);
		Debug.Log("BulletPrefabs " + BulletPrefabs.Length);
	}

	void Start() {
		SelectionToyPanel(0);
		SelectionBullet(0);
	}

	public void SelectionToyPanel(int index)
	{
        Image Image;
		GameObject toyPrefab;
	    for (int i = 0; i < ToysPanelsImage.Length; i++)
        {
			Image = ToysPanelsImage[i].transform.GetComponentInChildren<Image>();
			Image.color = defaultColor;
			Image.transform.localScale = Vector3.one * 1.0f;

			toyPrefab = BulletPrefabs[i];
			toyPrefab.SetActive(false);
		}

		Image = ToysPanelsImage[index].transform.GetComponentInChildren<Image>(); 
		Image.color = Color.yellow;
		Image.transform.localScale = Vector3.one * 1.1f;

		toyPrefab = BulletPrefabs[index];
		toyPrefab.SetActive(true);

		SelectionBullet(index);
	}

	public void SelectionBullet(int index)
	{		
		weapon = BulletCreator.GetComponent<Weapon>();

		weapon.enabled = true;
		weapon.selectionBullet = BulletPrefabs[index];
		weapon.enabled = false;

		BulletPrefabs[index].SetActive(true);
	}
}
