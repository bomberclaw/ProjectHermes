using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{

    private float t=0;
    private Coroutine coroutine;
    private Transform cam;

    private Vector3 aux;


    public float intensity;
    public float duration;



    private void Start()
    {
        cam = transform;

    }


    public void Shake()
    {

        if (coroutine == null) {
            coroutine = StartCoroutine(DoShake());
        }
      
    }

    private void Update()
    {
        
    }

    private int negative=1;

    IEnumerator DoShake( )
    {



        while (t < duration) {

            cam.position -= aux * negative * intensity;

            if (Random.value < 0.5f) {
                negative = -1;
            }
            else {
                negative = 1;
            }
       
            aux.x = Random.value ;
            aux.y = Random.value ;

   

            t += Time.deltaTime;
            if (t < duration) {
                cam.position += aux * negative * intensity;
            }
            yield return new WaitForEndOfFrame() ;
        }
      //  cam.position -= aux * negative * intensity;
        t = 0;
        coroutine = null;
        aux = Vector2.zero;
        negative = 1;
        
    }
}
