using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform spawnPosition;
    public Animator animController;
    public ProjectilePool pool;

    protected void Shoot()
    {
        if (animController != null) animController.SetTrigger("Shoot");

        if (pool.objPool.Count == 0)
        {
            CreateNewProjectile();
        }

        else
        {
            UseFromPool();
        }
    }

    private void CreateNewProjectile()
    {
        GameObject instance = Instantiate(projectile, spawnPosition.position, spawnPosition.rotation, pool.transform);
        Projectile projectileScript = instance.GetComponent<Projectile>();
        projectileScript.pool = pool;
        projectileScript.ShootProjectile();
    }

    private void UseFromPool()
    {
        GameObject instance = pool.objPool[0];
        pool.objPool.Remove(instance);
        instance.transform.position = spawnPosition.transform.position;
        instance.transform.rotation = spawnPosition.transform.rotation;
        Projectile projectileScript = instance.GetComponent<Projectile>();
        instance.SetActive(true);
        projectileScript.ShootProjectile();
    }
}
