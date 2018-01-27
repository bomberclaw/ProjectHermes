using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
	public  float       force = 10;
	private Rigidbody2D myRigidbody;
	private Vector3     auxRotation;
	public  int         remainingBounces = 5;

	private void Start()
	{
		myRigidbody = GetComponent<Rigidbody2D>();
		myRigidbody.velocity = transform.forward * force;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Reflect"))
			remainingBounces--;
		else
			remainingBounces = 0;
		if (remainingBounces <= 0)
			Destroy(this.gameObject);
		else
			transform.LookAt(transform.position + (Vector3)myRigidbody.velocity, Vector3.back);
		transform.rotation.eulerAngles *= new Vector3(1, 0, 1);
//		auxRotation = transform.rotation.eulerAngles;
//		auxRotation.x = Vector2.Angle(Vector2.right, myRigidbody.velocity);
//		transform.rotation = Quaternion.Euler(auxRotation);
//		myRigidbody.velocity = Vector2.Reflect(myRigidbody.velocity, collision.contacts[0].normal);
	}
}
