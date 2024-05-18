using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public positon spawn;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(("Player")))
        {
            spawn.position = gameObject.transform.position;
        }
    }
}
