using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToyPanelView : MonoBehaviour
{ 
	[SerializeField] GameObject ToysContent;
	
	private GameObject[] ToysPanels = new GameObject[0];
	private GameObject[] ToysPanelsImage = new GameObject[0];
	private Color defaultColor;

	private void Awake()
	{
		//Array to hold all child obj
		int ToysContentCount = ToysContent.transform.childCount;
		ToysPanels = new GameObject[ToysContentCount];
		ToysPanelsImage = new GameObject[ToysContentCount];

        for (int i = 0; i < ToysContentCount; i++)
        {
			GameObject child = ToysContent.transform.GetChild(i).gameObject;
			ToysPanels[i] = child;
            
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

	public void SelectionToyPanel(int index)
	{
        Image Image;
		//Убираем выделение со всех игрушек
        for (int i = 0; i < ToysPanelsImage.Length; i++)
        {
            Image = ToysPanelsImage[i].transform.GetComponentInChildren<Image>();
			Image.color = defaultColor;
			Image.transform.localScale = Vector3.one * 1.0f;
		}

		Image = ToysPanelsImage[index].transform.GetComponentInChildren<Image>(); 
		Image.color = Color.yellow;
		Image.transform.localScale = Vector3.one * 1.1f;

	}

}
