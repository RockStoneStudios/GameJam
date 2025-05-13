using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public int health;
    public int attackpower;
    [SerializeField] private float maxlifespan;
    [SerializeField] private float currentlifespan;

    public void TakeDamage(int amount)
    {
        health -= amount;
    }

    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<StatsManager>();
        if (atm != null)
        {
            atm.TakeDamage(attackpower);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentlifespan = maxlifespan;
    }

    // Update is called once per frame
    void Update()
    {
        currentlifespan -= Time.deltaTime * 1f;
        if (currentlifespan <= 0)
        {
            DestroyObject();
        }
        if (health <= 0)
        {
            DestroyObject();
        }
    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
