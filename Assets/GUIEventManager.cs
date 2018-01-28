using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIEventManager : MonoBehaviour
{
	static private GUIEventManager instance;
	private Animator myAnimator;
	public string eventFlagName = "eventFlag";

	private void Awake()
	{
		instance = this;
		myAnimator = GetComponent<Animator>();
	}

	static public void InvokeEvent(int eventFlag)
	{
		if (instance == null)
			return;

		if (instance.myAnimator.GetInteger(instance.eventFlagName) == 0)
			instance.myAnimator.SetInteger(instance.eventFlagName, eventFlag);
	}
}
