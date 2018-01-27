using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMover : MonoBehaviour
{
	public float movementDistance = 50;
	public float movementDuration = 4;
	public float durationOffset = 0;
	public Vector3 movementVector;
	public float delayOnGoal = 2;
	private float counter;
	private Vector3 startPosition;
	private Vector3 goalPosition;
	private Transform myTransform;


    public RandomMovement randomMovement;

	private void Start()
	{
		myTransform = transform;
		movementVector.Normalize();
		StartCoroutine(Move());
	}
	
	private IEnumerator Move()
	{
		counter = durationOffset;
		while (true)
		{
			startPosition = myTransform.position;
			goalPosition = startPosition + movementVector * movementDistance;
			while (counter < movementDuration)
			{
				myTransform.position = Vector3.Lerp(startPosition, goalPosition, counter / movementDuration);
				counter += Time.deltaTime;
				yield return new WaitForEndOfFrame();
			}
			myTransform.position = goalPosition;
			movementVector = -movementVector;

			counter = 0;
            if (randomMovement != null) { 
            randomMovement.pause = true;
            }
            yield return new WaitForSeconds(delayOnGoal);
            if (randomMovement != null) { 
            randomMovement.pause = false;
            }
            goalPosition = myTransform.localScale;
			goalPosition.x = -goalPosition.x;
			myTransform.localScale = goalPosition;
		}
	}
}
