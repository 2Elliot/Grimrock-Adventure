using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenRayCast : MonoBehaviour
{
    public Transform collectable;
    public Camera mainCamera;

    public bool toggle;

    bool clicked = false;

    public LayerMask layer;

    private void Update()
    {
        if (!toggle)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, 2, layer))
                {
                    collectable = hit.transform;
                }   
            }
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, 3, ~layer))
                {
                    collectable.position = hit.point + new Vector3(0f, 0.1f, 0f);
                }
            }
            if (Input.GetMouseButtonUp(0))
            {

                if (collectable != null)
                {
                    collectable = null;
                }
            }

        }
        else
        {
            if (clicked == false)
            {
                if (Input.GetMouseButtonDown(0))
                {

                    Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray2, out RaycastHit hit2, 2, layer))
                    {
                        collectable = hit2.transform;
                        clicked = true;
                    }
                }
            }
            else
            {
                if (clicked == true)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out RaycastHit hit, 3, ~layer))
                    {
                        collectable.position = hit.point + new Vector3(0f, 0.1f, 0f);
                    }
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (collectable != null)
                        {
                            collectable = null;
                            clicked = false;
                        }
                    }
                }
            }
        } 
    }

    public bool moving
    {
        get
        {
            if (collectable != null)
                return true;
            else
                return false;
        }
    }
}
