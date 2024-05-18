using System;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public float speedLift;

    public GameObject upTransform;
    public GameObject dounTransform;
    
    private Vector2 _positionLift;

    private float speed;

    private bool _up;
    private bool _doun;
    
    
    void Update()
    {
        _positionLift = gameObject.transform.position;

        speed = speedLift * Time.deltaTime;

        if (_up)
        {
            MoveDoun();
        }

        if (_doun)
        {
            MoveUp();
        }
    }

    public void MoveTowards()
    {
        if (_positionLift.Equals(upTransform.transform.position))
        {
            _up = true;
            _doun = false;
        }
        if (_positionLift.Equals(dounTransform.transform.position))
        {
            _doun = true;
            _up = false;
        }
    }

    void MoveUp()
    {
        transform.position = Vector2.MoveTowards(transform.position, upTransform.transform.position, speed);
    }

    void MoveDoun()
    {
        transform.position = Vector2.MoveTowards(transform.position, dounTransform.transform.position, speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        MoveTowards();
    }
}
