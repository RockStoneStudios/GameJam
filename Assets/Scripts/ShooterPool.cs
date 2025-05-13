using UnityEngine;
using System.Collections.Generic;

public class ShooterPool : MonoBehaviour
{
    public static ShooterPool Instance;

    public GameObject shooterPrefab;
    public int poolSize = 20;

    private Queue<GameObject> pool = new();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(shooterPrefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetShooter(Vector3 position)
    {
        if (pool.Count == 0)
        {
            Debug.LogWarning("Shooter pool exhausted.");
            return null;
        }

        GameObject obj = pool.Dequeue();
        obj.transform.position = position;
        obj.transform.rotation = shooterPrefab.transform.rotation;
        obj.SetActive(true);
        return obj;
    }

    public void ReturnShooter(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
