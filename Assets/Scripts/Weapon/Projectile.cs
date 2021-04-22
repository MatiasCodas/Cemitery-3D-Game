using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Weapon
{
    [SerializeField] private float force = 10f;
    public Rigidbody rb;
    public ProjectilePool pool;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    public void ShootProjectile()
    {
        rb.AddRelativeForce(Vector3.forward * -1 * force);
        Debug.Log("Shoot");
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        rb.transform.position = other.transform.position;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        pool.ReturnToPool(gameObject);
    }
}
