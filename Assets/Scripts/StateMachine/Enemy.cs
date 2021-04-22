using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private Transform enemy;
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed = -10f;
    [SerializeField] private float gravity;

    private Vector3 velocity;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void Follow()
    {
        Vector3 distance = player.transform.position - gameObject.transform.position;
        Vector3 moveDirection = transform.right * distance.x + transform.forward * distance.z;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(new Vector3(moveDirection.x, velocity.y,moveDirection.z) * moveSpeed * Time.deltaTime);
		enemy.LookAt(player.transform);
    }

	public void Attack(){

	}
}
