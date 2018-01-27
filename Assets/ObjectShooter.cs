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
			Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
			myPredictor.Toggle(canShoot);
		}
	}

	static public void ArrowDestroyed(bool resumeAiming)
	{
		if (resumeAiming)
		{
			instance.canShoot = true;
			instance.myPredictor.Toggle(instance.canShoot);
		}
	}
}