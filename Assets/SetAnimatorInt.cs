using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorInt : StateMachineBehaviour
{
	public string intName = "eventFlag";
	public int    value;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetInteger(intName, value);
	}
}
