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
	public  int                 availableArrows = 4;

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
			availableArrows--;
			canShoot = false;
			myRenderer.sprite = spriteWhileWaiting;
			Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
			myPredictor.Toggle(canShoot);
		}
	}

	static public void DisableShooting()
	{
		instance.canShoot = false;
		instance.myRenderer.sprite = instance.spriteWhileWaiting;
		instance.myPredictor.Toggle(instance.canShoot);
	}

	static public void EnableShooting()
	{
		instance.canShoot = true;
		instance.myRenderer.sprite = instance.spriteWhileFiring;
		instance.myPredictor.Toggle(instance.canShoot);
	}

	static public void ArrowDestroyed(bool resumeAiming)
	{
		if (resumeAiming)
		{
			if (instance.availableArrows > 0)
			{
				EnableShooting();
			}
			else
			{
				GUIEventManager.InvokeEvent(3);
			}
		}
	}
}