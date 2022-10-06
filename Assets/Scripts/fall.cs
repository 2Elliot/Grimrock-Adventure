using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class fall : MonoBehaviour
{
    public LayerMask layer;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = new Ray(transform.position, new Vector3(0, -1, 0));
            if (Physics.Raycast(ray, out RaycastHit hit, layer))
            {
                if ((transform.position.y - hit.transform.position.y) > 0.02f)
                {
                    transform.position = hit.point + new Vector3(0f, 0.005f, 0f); ;
                }
            }
        }
    }
}
