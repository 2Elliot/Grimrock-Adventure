using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenRayCast : MonoBehaviour
{
    public Camera mainCamera;

    public LayerMask layer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, 2, layer))
            {
                Debug.Log(hit.collider.name);
            }
        }
    }
}
