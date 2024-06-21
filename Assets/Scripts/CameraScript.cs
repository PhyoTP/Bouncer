
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    private GameObject ball;
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        ball = GameObject.Find("Sphere");
    }

    void Update()
    {
        transform.position = ball.transform.position;
        //mouse control
        transform.RotateAround(gameObject.transform.position, Vector3.up, Input.GetAxis("Mouse X"));
        transform.RotateAround(gameObject.transform.position, -transform.right, Input.GetAxis("Mouse Y"));

        gameObject.transform.Rotate(0, Input.GetAxis("Mouse X"), -transform.eulerAngles.z);

        if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        
    }


}