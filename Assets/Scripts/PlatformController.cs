using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private bool isGrounded = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isGrounded = false;
        }
    }

    void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.S))
        {
            // Действие при нажатии кнопки S на платформе
            Debug.Log("Вы спрыгнули с платформы");
        }
    }
}