using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenRayCast : MonoBehaviour
{

    public Camera mainCamera;

    public LayerMask layer;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out RaycastHit hit, 2, layer))
            {
                Debug.Log(hit.collider.name);

                hit.transform.position = hit.point;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out RaycastHit hit, 2, layer))
            {
                Physics.Raycast(ray, out RaycastHit mousePosition, 2, ~layer);
                hit.transform.position = mousePosition.transform.position;
            }
        }
    }
}
