using UnityEngine;

public class DamageTest : MonoBehaviour
{
    public StatsManager WBCAtm;
    public StatsManager PathogenAtm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            WBCAtm.DealDamage(PathogenAtm.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PathogenAtm.DealDamage(WBCAtm.gameObject);
        }
    }
}
