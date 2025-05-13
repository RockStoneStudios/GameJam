using UnityEngine;
using UnityEngine.UI;

public class TankCard : MonoBehaviour
{
    public static TankCard selectedCard = null;

    public int cost = 25;
    public Button cardButton;

    void Start()
    {
        cardButton.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (ResourceManager.Instance.currentResource >= cost)
        {
            selectedCard = this;
            Debug.Log("Shooter selected.");
        }
        else
        {
            Debug.Log("Not enough resources to select this card.");
        }
    }

    public bool TryUseCard()
    {
        return ResourceManager.Instance.TrySpend(cost);
    }
}
