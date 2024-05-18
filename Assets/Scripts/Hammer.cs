using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public Collider2D coll;

    public positon position;

    public void CollOff()
    {
        coll.enabled = !coll.enabled;
    }

    public void CollON()
    {
        coll.enabled = coll.enabled;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Player"))
        {
            var player = other.gameObject.GetComponent<PlayerMovement>();
            player.transform.position = position.position;
        }
    }
}
