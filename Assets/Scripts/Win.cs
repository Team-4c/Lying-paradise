using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.GetComponent<CharacterController2D>() != null)
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index - 1);
        }
    }
}
