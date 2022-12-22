using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToyPanelView : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] GameObject ToysContent;

	private GameObject[] Toys = new GameObject[0];

	private void Awake()
	{
		int i = 0;
		//Array to hold all child obj
		Toys = new GameObject[ToysContent.transform.childCount];
		
		foreach (Transform child in ToysContent.transform)
		{
			Toys[i] = child.gameObject;
			Debug.Log(Toys[i].gameObject.name.ToString());
			i += 1;
		}
	}

	public void SelectionToy(int index)
    {

    }


	public void OnPointerClick(PointerEventData eventData)
    {
		
	}

    public void OnPointerEnter(PointerEventData eventData)
	{
		transform.localScale = Vector3.one * 1.2f;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		transform.localScale = Vector3.one * 1.0f;
	}
}
