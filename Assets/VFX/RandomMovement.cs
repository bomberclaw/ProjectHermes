using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{

    private Vector2 originalPos;
    private Vector2 movedPos;
    public Vector2 positionOffset;

    private bool isUp;

    public bool pause;
    public float rotation;

    public float delay=0.5f;

    private void Start()
    {
        StartCoroutine(doMove(delay));
        originalPos = transform.localPosition;
        movedPos = (Vector2)transform.localPosition + positionOffset;
    }



    IEnumerator doMove(float delay)
    {
        while (true) {
            if (pause) {
                yield return new WaitForEndOfFrame();
            }
            else {
                yield return new WaitForSeconds(delay);
                if (isUp) {
                    isUp = false;
                    transform.localPosition = originalPos;
                    transform.localRotation = Quaternion.Euler(0 , 0 , rotation);
                }
                else {
                    isUp = true;
                    transform.localPosition = movedPos;
                    transform.localRotation = Quaternion.Euler(0 , 0 , -rotation);
                }
            }
        }

    }


}
