using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour 
{
	[SerializeField] private float mouseSensitivity = 100f;
	[SerializeField] private Transform player;
	private float xRotation = 0f;

	private void Start() 
	{
		Cursor.lockState = CursorLockMode.Locked;
	}
	private void Update()
	{
		RotateCamera();
	}

	private void RotateCamera()
	{
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;	
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;	

		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation,-90f,90f);

		transform.localRotation = Quaternion.Euler(xRotation,0,0);
		player.Rotate(Vector3.up * mouseX);
	}
}
