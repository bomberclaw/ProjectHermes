using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntervalRotator : MonoBehaviour
{
	private Transform myTransform;

	public float interval = 3;
	public float angle    = 90;
	public float rotationDuration = 0.5f;
	public Quaternion startRotation;
	public Quaternion targetRotation;

	private void Awake()
	{
		myTransform = transform;
		StartCoroutine(RotationRoutine());
	}

	private IEnumerator RotationRoutine()
	{
		float remainingDuration;
		while (true)
		{
			yield return new WaitForSeconds(interval);
			remainingDuration = rotationDuration;
			startRotation = myTransform.rotation;
			targetRotation = Quaternion.Euler(startRotation.eulerAngles + Vector3.forward * angle);
			while (remainingDuration > 0)
			{
				myTransform.rotation = Quaternion.Lerp(targetRotation, startRotation, remainingDuration / rotationDuration);
				remainingDuration -= Time.deltaTime;
				yield return new WaitForEndOfFrame();
			}
			myTransform.rotation = targetRotation;
		}
	}
}
