using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
	private Transform      myTransform;
	private Vector3        auxPosition;
	private SpriteRenderer mySprite;
	private bool           previousFlipState;
	public  Transform      spawnPoint;
	private Vector3        auxVector;

	private void Awake()
	{
		myTransform = transform;
		mySprite    = GetComponentInChildren<SpriteRenderer>();
		previousFlipState = mySprite.flipY;
	}

	private void Update()
	{
		auxPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		auxPosition.z = 0;
		myTransform.LookAt(auxPosition);
		mySprite.flipY = myTransform.rotation.eulerAngles.y > 180;
		if (mySprite.flipY != previousFlipState)
		{
			previousFlipState = mySprite.flipY;
			auxVector = spawnPoint.localPosition;
			auxVector.y = -auxVector.y;
			spawnPoint.localPosition = auxVector;
		}
//		transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z));
	}
}
