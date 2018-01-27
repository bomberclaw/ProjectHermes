using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIEventInvoker : MonoBehaviour
{
	public int eventFlag = 1;
	private void OnCollisionEnter2D()
	{
		GUIEventManager.InvokeEvent(eventFlag);
	}
}
