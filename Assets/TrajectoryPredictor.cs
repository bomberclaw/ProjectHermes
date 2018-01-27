using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryPredictor : MonoBehaviour
{
	private LineRenderer  lineRenderer;
	private Transform     myTransform;
	private List<Vector3> linePoints;
	public  LayerMask     hitLayers;
	private RaycastHit2D  raycastHit;
	private int           raycastHitCount;
	public  int           maxBounces = 4;

	private void Start()
	{
		myTransform = transform;
		lineRenderer = GetComponent<LineRenderer>();
		linePoints = new List<Vector3>();
		StartCoroutine(Recalculate());
	}

	private IEnumerator Recalculate()
	{
		Vector2 startPoint, direction;
		while (true)
		{
			startPoint = (Vector2)myTransform.position;
			direction = (Vector2)myTransform.forward;
			linePoints.Clear();
			linePoints.Add(myTransform.position);
			bool hitDeflectable = false;
			int bounces = 0;
			do
			{
				raycastHit = Physics2D.Raycast(startPoint, direction);
				if (raycastHit != null)
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
			yield return new WaitForEndOfFrame();
		}
	}
}