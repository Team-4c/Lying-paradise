using UnityEngine;
using System.Collections;

public class HamerState : MonoBehaviour
{
    public Transform impactPoint;
    public Vector2 originalPosition;
    public float hitDelay = 2f;
    public float hammerSpeed = 5f;

    void Start()
    {
        // Сохраняем изначальную позицию молота
        originalPosition = transform.position;
        
        // Запускаем цикл "удара" молота
        StartCoroutine(HammerSequence());
    }

    IEnumerator HammerSequence()
    {
        while (true)
        {
            yield return new WaitForSeconds(hitDelay);

            // Движение молота к точке удара
            StartCoroutine(MoveHammer(impactPoint.position));

            yield return new WaitForSeconds(1.5f);

            // Возврат молота на исходную позицию
            StartCoroutine(MoveHammer(originalPosition));
        }
    }

    IEnumerator MoveHammer(Vector2 targetPosition)
    {
        while ((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, hammerSpeed * Time.deltaTime);
            yield return null;
        }
    }
}