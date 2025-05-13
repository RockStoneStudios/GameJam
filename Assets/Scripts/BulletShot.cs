using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BulletShot : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab;
    public float shootInterval = 1f;
    public float projectileSpeed = 10f;

    [Header("Internal References")]
    public Transform spawnPoint;
    private float baseInterval;
    private Coroutine shootRoutine;
    private void Start()
    {
        baseInterval = shootInterval;
        GlobalSkillManager.Register(this);
        shootRoutine = StartCoroutine(ShootLoop());
    }
    private void OnDestroy()
    {
        GlobalSkillManager.Unregister(this);
    }
    IEnumerator ShootLoop()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(shootInterval);
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = spawnPoint.forward * projectileSpeed;
        }
        else
        {
            // fallback if no Rigidbody: move manually
            projectile.AddComponent<SimpleProjectile>().speed = projectileSpeed;
        }
    }
    public void SetFireRate(float interval)
    {
        shootInterval = interval;

        if (shootRoutine != null)
        {
            StopCoroutine(shootRoutine);
            shootRoutine = StartCoroutine(ShootLoop());
        }
    }
    public void ResetFireRate()
    {
        SetFireRate(baseInterval);
    }
}

public class SimpleProjectile : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
