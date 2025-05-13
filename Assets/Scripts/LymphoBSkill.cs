using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class LymphoBSkill : MonoBehaviour
{
    public float skillDuration = 5f;
    public float skillCooldown = 10f;
    public int cost = 3;
    private BulletShot shooter;
    

    void Start()
    {
        shooter = GetComponent<BulletShot>();
        if (shooter == null)
        {
            Debug.LogError($"{name}: No Shooter component found!");
            enabled = false;
            return;
        }

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Right-click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                    if (ResourceManager.Instance.TrySpend(cost))
                    {
                        float boostedInterval = shooter.shootInterval / 2f;
                        GlobalSkillManager.TryActivateSkill(this, skillDuration, skillCooldown, boostedInterval);
                    }
                    else
                    {
                        Debug.Log("Not enough energy to activate skill.");
                    }
                }
            }
        }
    }
}
