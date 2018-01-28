using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleShooting : StateMachineBehaviour
{
	public enum FiringMoment
	{
		Enter,
		Exit
	}

	public bool         enablesShooting = true;
	public FiringMoment firingMoment;


	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (firingMoment == FiringMoment.Enter)
			Execute();
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (firingMoment == FiringMoment.Exit)
			Execute();
	}

	private void Execute()
	{
		if (enablesShooting)
			ObjectShooter.EnableShooting();
		else
			ObjectShooter.DisableShooting();
	}
}
