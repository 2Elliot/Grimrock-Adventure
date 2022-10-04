using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    public Transform cameraController;

    void Update()
    {
        transform.position = cameraController.position;
        transform.rotation = cameraController.rotation;
    }
}
