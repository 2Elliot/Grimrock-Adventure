using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugScript : MonoBehaviour
{

	playerController controller;

	private void Awake()
	{
		controller = GetComponent<playerController>();
	}

	void Update()
    {

		Ray forwardRay = new Ray(transform.position, transform.forward);
		Ray backwardRay = new Ray(transform.position, -transform.forward);
		Ray leftRay = new Ray(transform.position, -transform.right);
		Ray rightRay = new Ray(transform.position, transform.right);

		RaycastHit forwardHit;
		RaycastHit backwardHit;
		RaycastHit leftHit;
		RaycastHit rightHit;

		if (Physics.Raycast(forwardRay, out forwardHit, controller.travelDistance))
			Debug.DrawLine(forwardRay.origin, forwardHit.point, Color.red);
		else
			Debug.DrawLine(forwardRay.origin, forwardRay.origin + forwardRay.direction * controller.travelDistance, Color.green);


		if (Physics.Raycast(backwardRay, out backwardHit, controller.travelDistance))
			Debug.DrawLine(backwardRay.origin, backwardHit.point, Color.red);
		else
			Debug.DrawLine(backwardRay.origin, backwardRay.origin + backwardRay.direction * controller.travelDistance, Color.green);

		if (Physics.Raycast(leftRay, out leftHit, controller.travelDistance))
			Debug.DrawLine(leftRay.origin, leftHit.point, Color.red);
		else
			Debug.DrawLine(leftRay.origin, leftRay.origin + leftRay.direction * controller.travelDistance, Color.green);

		if (Physics.Raycast(rightRay, out rightHit, controller.travelDistance))
			Debug.DrawLine(rightRay.origin, rightHit.point, Color.red);
		else
			Debug.DrawLine(rightRay.origin, rightRay.origin + rightRay.direction * controller.travelDistance, Color.green);

	}
}
