using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCamera : MonoBehaviour
{
    Camera targetCamera;
    // Start is called before the first frame update
    void Start()
    {
        targetCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = targetCamera.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(targetCamera.transform.position - v);
        transform.rotation = (targetCamera.transform.rotation);
    }
}
