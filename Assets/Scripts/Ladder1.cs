using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder1 : MonoBehaviour
{
    [SerializeField]

    float speed = 5;
    private bool flag;

    void Start()
    {
   
    }

     void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("ladder"))
        {
            flag = true;
        }




    }
    void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
    private void Update()
    {
        if (flag)
        {
            if (Input.GetButton("Up"))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);

            }
            else if (Input.GetButton("Down"))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
        
        flag = false;
    }
}
