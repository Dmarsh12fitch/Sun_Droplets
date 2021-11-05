using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(coll.gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(coll.gameObject);
    }

}
