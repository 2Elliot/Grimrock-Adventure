using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(playerController))]
public class playerInput : MonoBehaviour
{

	public KeyCode forward = KeyCode.W;
	public KeyCode backward = KeyCode.S;
	public KeyCode left = KeyCode.A;
	public KeyCode right = KeyCode.D;
	public KeyCode turnLeft = KeyCode.Q;
	public KeyCode turnRight = KeyCode.E;

	public float sensX;
	public float sensY;

	public Transform orientation;

	float xRotation;
    float yRotation;
	float prevYRotation;

	playerController controller;

	private bool rightClick;

    private void Awake()
	{

		controller = GetComponent<playerController>();

	}

	private void Update()
	{

		if (Input.GetKeyDown(KeyCode.Mouse1) && controller.AtRest)
		{
			rightClick = true;
			yRotation = orientation.rotation.eulerAngles.y;
			prevYRotation = yRotation;
			controller.canMove = -1;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		else if (Input.GetKeyUp(KeyCode.Mouse1))
		{
			controller.canMove = 1;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			xRotation = 0f;
			rightClick = false;
		}

		if (Input.GetMouseButton(1) && rightClick)
		{

			float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * (sensX);
			float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * (sensY);

			yRotation += mouseX;
			xRotation -= mouseY;

			xRotation = Mathf.Clamp(xRotation, -60f, 60f);
			yRotation = Mathf.Clamp(yRotation, prevYRotation - 75f, prevYRotation + 75f);

			transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
		}

		else
		{

			if (Input.GetKeyUp(forward) && controller.CanMoveForward) controller.MoveForward();
			else if (Input.GetKeyUp(forward) && !controller.CanMoveForward) controller.FalseForward();

			if (Input.GetKeyUp(backward) && controller.CanMoveBackward) controller.MoveBackward();
			else if (Input.GetKeyUp(backward) && !controller.CanMoveBackward) controller.FalseBackward();

			if (Input.GetKeyUp(left) && controller.CanMoveLeft) controller.MoveLeft();
			else if (Input.GetKeyUp(left) && !controller.CanMoveLeft) controller.FalseLeft();

			if (Input.GetKeyUp(right) && controller.CanMoveRight) controller.MoveRight();
			else if (Input.GetKeyUp(right) && !controller.CanMoveRight) controller.FalseRight();

			if (Input.GetKeyUp(turnLeft)) controller.RotateLeft();
			if (Input.GetKeyUp(turnRight)) controller.RotateRight();
		}

	}

}
