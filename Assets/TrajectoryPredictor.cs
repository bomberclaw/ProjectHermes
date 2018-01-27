using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryPredictor : MonoBehaviour
{
	private LineRenderer  lineRenderer;
	public  Transform     shootingPoint;
	private List<Vector3> linePoints;
	public  LayerMask     hitLayers;
	private RaycastHit2D  raycastHit;
	private int           raycastHitCount;
	public  int           maxBounces = 4;
	private bool          isActive;
	private Vector2       startPoint;
	private Vector2       direction;

	private void Start()
	{
		lineRenderer = GetComponent<LineRenderer>();
		linePoints = new List<Vector3>();
		isActive = true;
	}

	public void Toggle(bool active)
	{
		enabled = active;
		lineRenderer.enabled = active;
	}

	private void Update()
	{
	startPoint = (Vector2)shootingPoint.position;
		direction = (Vector2)shootingPoint.forward;
		linePoints.Clear();
		linePoints.Add(shootingPoint.position);
		bool hitDeflectable = false;
		int bounces = 0;
		do
		{
			raycastHit = Physics2D.Raycast(startPoint, direction);
			if (raycastHit.collider != null)
			{
				if (raycastHit.collider.CompareTag("Reflect"))
				{
					hitDeflectable = true;
					direction = Vector2.Reflect(direction, raycastHit.normal);
					startPoint = raycastHit.point + raycastHit.normal;
				}
				linePoints.Add(raycastHit.point);
			}
			bounces++;
		} while (hitDeflectable && bounces < maxBounces);

		lineRenderer.positionCount = linePoints.Count;
		lineRenderer.SetPositions(linePoints.ToArray());
	}
}