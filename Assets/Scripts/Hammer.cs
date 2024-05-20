
using UnityEngine;

public class Hammer : MonoBehaviour
{
    
    public positon position;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Player"))
        {
            var player = other.gameObject.GetComponent<PlayerMovement>();
            player.transform.position = position.position;
        }
    }
}
