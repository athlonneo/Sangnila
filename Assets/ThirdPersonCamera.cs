using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public float RotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY, scroll, distance;
    public float minDistance, maxDistance;
    bool paused;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        if (!paused)
        {
            mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
            mouseY = Mathf.Clamp(mouseY, -35, 60);

            transform.LookAt(Target);

            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);

            scroll = Input.GetAxis("Mouse ScrollWheel");
            distance = Vector3.Distance(this.transform.position, Target.transform.position);
            if (scroll > 0f && distance >= minDistance)
            {
                this.transform.Translate(Vector3.forward);
            }
            else if (scroll < 0f && distance <= maxDistance)
            {
                this.transform.Translate(-Vector3.forward);
            }
        }
    }

    public void Pause()
    {
        if (!paused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            paused = true;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            paused = false;
        }
    }
}
