using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
	private Transform myTransform;
	private Vector3 auxPosition;

	private void Awake()
	{
		myTransform = transform;
	}

	private void Update()
	{
		auxPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		auxPosition.z = 0;
		myTransform.LookAt(auxPosition);
	}
}
