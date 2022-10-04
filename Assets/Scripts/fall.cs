using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class fall : MonoBehaviour
{
    public LayerMask layer;

    void Update()
    {
        Ray ray = new Ray(transform.position, new Vector3(0, -1, 0));

        Debug.DrawRay(transform.position, new Vector3(0, -1, 0), Color.red);

        if (Physics.Raycast(ray, out RaycastHit hit, layer))
        {
            Debug.Log(hit.transform.name);
            Debug.Log(transform.position.y - hit.transform.position.y);
            if ((transform.position.y - hit.transform.position.y) > 0.02f)
            {
                transform.position = new Vector3(transform.position.x, hit.transform.position.y + 0.01f, transform.position.z);
            }
        }


    }
}
