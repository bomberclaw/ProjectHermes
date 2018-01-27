using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantShaker : MonoBehaviour
{

    private float t=0;
    private Coroutine coroutine;
    private Transform cam;
    private Vector3 aux;
	private int negative=1;
	private Vector3 oldPosition;

    public float intensity;

    private void Start()
    {
        cam = transform;
		oldPosition = cam.localPosition;
		coroutine = StartCoroutine(DoShake());
    }

    IEnumerator DoShake( )
    {	
		while (true) {

			cam.localPosition = oldPosition;

            if (Random.value < 0.5f) {
                negative = -1;
            }
            else {
                negative = 1;
            }
       
            aux.x = Random.value ;
            aux.y = Random.value ;
			cam.localPosition += aux * negative * intensity;

			yield return new WaitForEndOfFrame() ;
        }
        coroutine = null;
        aux = Vector2.zero;
        negative = 1;
        
    }
}
