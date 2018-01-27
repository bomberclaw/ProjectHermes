using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShooter : MonoBehaviour
{
	public GameObject prefab;
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			Instantiate(prefab, transform.position, transform.rotation);
		}
	}
}
