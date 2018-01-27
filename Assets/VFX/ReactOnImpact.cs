using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactOnImpact : MonoBehaviour {

    public Shaker shaker;
    public GameObject particle;
    GameObject part;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (shaker != null) {
            shaker.Shake();
        }


        if (particle != null) {
          part=  Instantiate(particle, collision.contacts[0].point, Quaternion.identity);
            part.transform.forward = -collision.contacts[0].normal;
            part.SetActive(true);
            

        }
    }
}
