using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2.8f, 0);
    public bool smoothFollow = true;

    Vector2 moveToPos;
    bool beginMove = false;
    float distanceTmp = 0f;

    // Update is called once per frame
    void LateUpdate()
    {
        if (!target)
            return;

        if (smoothFollow)
        {
            distanceTmp = ((target.position + offset) - transform.position).sqrMagnitude;
            if (beginMove)
            {
                moveToPos = Vector3.Lerp(moveToPos, target.position + offset, Time.fixedDeltaTime * 7.75f);
                transform.position = new Vector3(moveToPos.x, moveToPos.y, -10);

                if (distanceTmp < 0.05f * 0.05f)
                {
                    beginMove = false;
                }
            }
            else
            {
                if (distanceTmp > 0.5f * 0.5f)
                {
                    beginMove = true;
                }
            }
        }
        else
        {
            transform.position = new Vector3(target.position.x, target.position.y, -10);
        }

    }

    void StopFollowing()
    {
        beginMove = false;
    }
}
