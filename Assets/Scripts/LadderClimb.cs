using JetBrains.Annotations;
using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    
    public float speedClimb;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Player") & Input.GetKey(KeyCode.S))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speedClimb);
        }

        if (other.tag == ("Player") & Input.GetKey(KeyCode.W))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speedClimb);
        }
        if (other.tag == ("Player") & !Input.GetKey(KeyCode.W) & !Input.GetKey(KeyCode.S))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);
        }
    }
}
