using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallsx : MonoBehaviour
{
    [SerializeField, Range(0, 1), Tooltip("0 - неподвижен, 1 - следует за камерой")]
    private float parallaxStrength;

    private Transform _camera;
    private Vector3 previousCamPosition;

    private void OnEnable()
    {
        _camera = Camera.main.transform;
        previousCamPosition = _camera.position;
    }

    private void Update()
    {
        if (!_camera) return;
        var position = _camera.position;
        Vector3 delta = Vector3.right * (position.x - previousCamPosition.x) * parallaxStrength;
        transform.Translate(delta);
        previousCamPosition = position;
    }

}

