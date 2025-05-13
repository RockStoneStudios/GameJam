using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    public int currentResource = 50;
    public int maxResource = 999;
    public int regenRate = 1;         // Amount regenerated
    public float regenInterval = 1f;  // Seconds

    public Text resourceText;         // Assign in Inspector

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateUI();
        InvokeRepeating(nameof(Regenerate), regenInterval, regenInterval);
    }

    void Regenerate()
    {
        if (currentResource < maxResource)
        {
            currentResource += regenRate;
            UpdateUI();
        }
    }

    public bool TrySpend(int amount)
    {
        if (currentResource >= amount)
        {
            currentResource -= amount;
            UpdateUI();
            return true;
        }

        Debug.Log("Not enough resources!");
        return false;
    }

    void UpdateUI()
    {
        if (resourceText != null)
            resourceText.text = $"Resources: {currentResource}";
    }
}