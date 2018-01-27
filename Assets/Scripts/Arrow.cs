using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
	public  float       force = 10;
	private Rigidbody2D myRigidbody;
	private Vector3     auxRotation;
	public  int         remainingBounces = 5;
	private int         maxBounces;
	private AudioSource myAudioSource;
	private SpriteRenderer mySprite;

	private void Start()
	{
		myRigidbody = GetComponent<Rigidbody2D>();
		myRigidbody.velocity = transform.forward * force;
		myAudioSource = GetComponent<AudioSource>();
		mySprite = GetComponentInChildren<SpriteRenderer>();
		maxBounces = remainingBounces;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		myAudioSource.Play();
		myAudioSource.pitch += 0.05f;
		if (collision.collider.CompareTag("Reflect"))
			remainingBounces--;
		else
			remainingBounces = 0;
		if (remainingBounces <= 0)
		{
			ObjectShooter.ArrowDestroyed(true);
			StartCoroutine(DestroyAfterAudio());
		}
		else
			transform.LookAt(transform.position + (Vector3)myRigidbody.velocity);
//		auxRotation = transform.rotation.eulerAngles;
//		auxRotation.x = Vector2.Angle(Vector2.right, myRigidbody.velocity);
//		transform.rotation = Quaternion.Euler(auxRotation);
//		myRigidbody.velocity = Vector2.Reflect(myRigidbody.velocity, collision.contacts[0].normal);
	}

	private bool audioIsPlaying()
	{
		return myAudioSource.isPlaying;
	}

	private IEnumerator DestroyAfterAudio()
	{
		enabled = false;
		mySprite.enabled = false;
		yield return new WaitWhile(audioIsPlaying);
		Destroy(this.gameObject);
	}
}
