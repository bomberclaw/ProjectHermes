using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShooter : MonoBehaviour
{
	static private ObjectShooter instance;

	public  GameObject          prefab;
	public  Transform           spawnPoint;
	private TrajectoryPredictor myPredictor;
	private bool                canShoot;
	public  SpriteRenderer      myRenderer;
	public  Sprite              spriteWhileFiring;
	public  Sprite              spriteWhileWaiting;

	private void Awake()
	{
		instance = this;
		myPredictor = GetComponent<TrajectoryPredictor>();
		canShoot = true;
	}

	private void Update()
	{
		if (canShoot && Input.GetKeyDown(KeyCode.Mouse0))
		{
			canShoot = false;
			myRenderer.sprite = spriteWhileWaiting;
			Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
			myPredictor.Toggle(canShoot);
		}
	}

	static public void ArrowDestroyed(bool resumeAiming)
	{
		if (resumeAiming)
		{
			instance.canShoot = true;
			instance.myRenderer.sprite = instance.spriteWhileFiring;
			instance.myPredictor.Toggle(instance.canShoot);
		}
	}
}