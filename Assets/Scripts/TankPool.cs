using UnityEngine;
using System.Collections.Generic;

public class TankPool : MonoBehaviour
{
    public static TankPool Instance;

    public GameObject tankPrefab;
    public int poolSize = 7;

    private Queue<GameObject> pool = new();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(tankPrefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetTank(Vector3 position)
    {
        if (pool.Count == 0)
        {
            Debug.LogWarning("Tank pool exhausted.");
            return null;
        }

        GameObject obj = pool.Dequeue();
        obj.transform.position = position;
        obj.transform.rotation = tankPrefab.transform.rotation;
        obj.SetActive(true);
        return obj;
    }

    public void ReturnTank(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}