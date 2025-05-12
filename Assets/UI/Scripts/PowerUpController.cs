using UnityEngine;
using UnityEngine.UI;

public class PowerUpButtonController : MonoBehaviour
{
    public Image buttonImage;          // The image component of the button
    public Sprite activeSprite;        // Normal sprite when Power-Up is ready
    public Sprite inactiveSprite;      // Grayscale or dimmed sprite
    public Slider chargeSlider;        // Slider UI element representing the charge

    public float chargeSpeed = 20f;    // How fast it fills per second

    private bool isCharged = false;

    void Start()
    {
        if (buttonImage != null && inactiveSprite != null)
        {
            buttonImage.sprite = inactiveSprite;
        }

        if (chargeSlider != null)
        {
            chargeSlider.value = 0f;
        }
    }

    void Update()
    {
        // Fill the bar gradually until it's full
        if (!isCharged && chargeSlider != null)
        {
            chargeSlider.value += chargeSpeed * Time.deltaTime;

            if (chargeSlider.value >= chargeSlider.maxValue)
            {
                FullyCharged();
            }
        }
    }

    void FullyCharged()
    {
        isCharged = true;

        if (buttonImage != null && activeSprite != null)
        {
            buttonImage.sprite = activeSprite;
        }

        Debug.Log("Power-Up Ready!");
    }

    // Optional: Call this when the power-up is used to restart the process
    public void ResetCharge()
    {
        isCharged = false;

        if (buttonImage != null && inactiveSprite != null)
        {
            buttonImage.sprite = inactiveSprite;
        }

        if (chargeSlider != null)
        {
            chargeSlider.value = 0f;
        }
    }
}
