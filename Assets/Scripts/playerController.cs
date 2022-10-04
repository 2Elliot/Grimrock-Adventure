using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class playerController : MonoBehaviour
{


	public float transitionSpeed = 8f;
    public float transitionRotationSpeed = 500f;
	public int travelDistance = 2;
	public float bumpTravelDistance = 2.5f;

	public int canMove = 1;

	public LayerMask layer;

    Vector3 targetGridPos;
    Vector3 prevTargetGridPos;
    Vector3 targetRotation;

	private void Start()
    {
        targetGridPos = Vector3Int.RoundToInt(transform.position);
    }

    private void FixedUpdate()
    {
        movePlayer();
    }

    private void movePlayer()
    {

		if (canMove == 1)
		{
			prevTargetGridPos = targetGridPos;

			if (targetRotation.y > 270f && targetRotation.y < 361f) targetRotation.y = 0f;
			if (targetRotation.y < 0f) targetRotation.y = 270f;

			transform.SetPositionAndRotation(Vector3.MoveTowards(transform.position, targetGridPos, Time.deltaTime * transitionSpeed), 
			Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * transitionRotationSpeed));
		}
		else if (canMove == 0)
		{
			transform.position = Vector3.MoveTowards(transform.position, targetGridPos, Time.deltaTime * transitionSpeed);
			if (AtRest) {
				targetGridPos = prevTargetGridPos;
				canMove = 1;
			}
		}
	}

    public void MoveForward() { if (AtRest) targetGridPos += travelDistance * transform.forward; }
	public void MoveBackward() { if (AtRest) targetGridPos -= travelDistance * transform.forward; }
	public void MoveLeft() { if (AtRest) targetGridPos -= travelDistance * transform.right; }
	public void MoveRight() { if (AtRest) targetGridPos += travelDistance * transform.right; }
	public void RotateLeft() { if (AtRest) targetRotation -= Vector3.up * 90f; }
	public void RotateRight() { if (AtRest) targetRotation += Vector3.up * 90f; }

	public void FalseForward() { if (AtRest) targetGridPos += (travelDistance * transform.forward) / bumpTravelDistance; canMove = 0; }
	public void FalseBackward() { if (AtRest) targetGridPos -= (travelDistance * transform.forward) / bumpTravelDistance; canMove = 0; }
	public void FalseLeft() { if (AtRest) targetGridPos -= (travelDistance * transform.right) / bumpTravelDistance; canMove = 0; }
	public void FalseRight() { if (AtRest) targetGridPos += (travelDistance * transform.right) / bumpTravelDistance; canMove = 0; }

	public bool CanMoveForward
	{
		get
		{
			var ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, travelDistance, layer))
				return false;
			else
				return true;
		}
	}
	public bool CanMoveBackward
	{
		get
		{
			var ray = new Ray(transform.position, -transform.forward);
			if (Physics.Raycast(ray, out RaycastHit hit, travelDistance, layer))
				return false;
			else
				return true;
		}
	} 
	public bool CanMoveLeft
	{
		get
		{
			var ray = new Ray(transform.position, -transform.right);
			if (Physics.Raycast(ray, out RaycastHit hit, travelDistance, layer))
				return false;
			else
				return true;
		}
	}
	public bool CanMoveRight
	{
		get
		{
			var ray = new Ray(transform.position, transform.right);
			if (Physics.Raycast(ray, out RaycastHit hit, travelDistance, layer))
				return false;
			else
				return true;
		}
	}


	public bool AtRest
    {
        get
        {
            if ((Vector3.Distance(transform.position, targetGridPos) < 0.05f) && 
                (Vector3.Distance(transform.eulerAngles, targetRotation) < 0.05f))
                return true;
            else
                return false;
        }
    }

}
