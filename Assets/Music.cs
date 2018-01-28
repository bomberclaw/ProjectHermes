using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
	static private Music instance;
	private void Awake()
	{
		if (instance == null)
		{
			DontDestroyOnLoad(this.gameObject);
			instance = this;
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
}
