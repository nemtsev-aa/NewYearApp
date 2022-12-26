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
	private GameObject[] ToysPanelsImage = new GameObject[0];
	private GameObject[] ArrayPrefabs = new GameObject[0];
	private Weapon weapon;

	private Color defaultColor;

	private void Awake()
	{
		//Array to hold all child obj
		int ToysContentCount = ToysContent.transform.childCount;
		ToysPanels = new GameObject[ToysContentCount];
		ToysPanelsImage = new GameObject[ToysContentCount];
		ArrayPrefabs = new GameObject[ToysContentCount];

        for (int i = 0; i < ToysContentCount; i++)
        {
			GameObject child = ToysContent.transform.GetChild(i).gameObject;
			ToysPanels[i] = child;

			GameObject pref = BulletCreator.transform.GetChild(i).gameObject;
			ArrayPrefabs[i] = pref;
            
            foreach (Transform iImage in child.transform)
            {
                if (iImage.name == "Backgroung")
                {
                    ToysPanelsImage[i] = iImage.gameObject;
					defaultColor = iImage.gameObject.GetComponent<Image>().color;
                    continue;
                }
            }
        }
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

			toyPrefab = ArrayPrefabs[i];
			toyPrefab.SetActive(false);
		}

		Image = ToysPanelsImage[index].transform.GetComponentInChildren<Image>(); 
		Image.color = Color.yellow;
		Image.transform.localScale = Vector3.one * 1.1f;

		SelectionBullet(index);
	}

	public void SelectionBullet(int index){
				
		weapon = BulletCreator.GetComponent<Weapon>();

		weapon.enabled = true;
		weapon.bullet = ArrayPrefabs[index];
		weapon.enabled = false;

		ArrayPrefabs[index].SetActive(true);
	}
}
