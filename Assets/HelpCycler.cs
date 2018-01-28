using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpCycler : MonoBehaviour
{
	private GameObject[] children;
	private int          currentIndex;

	private void Awake()
	{
		children = new GameObject[transform.childCount];
		for (int i = 0; i < transform.childCount; i++)
		{
			children[i] = transform.GetChild(i).gameObject;
		}
	}

	public void Next()
	{
		children[currentIndex].SetActive(false);
		currentIndex++;
		if (currentIndex >= children.Length)
			currentIndex = 0;
		children[currentIndex].SetActive(true);
	}

	public void Previous()
	{
		children[currentIndex].SetActive(false);
		currentIndex--;
		if (currentIndex < 0)
			currentIndex = children.Length - 1;
		children[currentIndex].SetActive(true);
	}
}
