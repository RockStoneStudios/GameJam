using UnityEngine;
using UnityEngine.UI;

public class CambiarSpriteAlClick : MonoBehaviour
{
    public Sprite nuevoSprite;
    private Image imagen;

    void Start()
    {
        imagen = GetComponent<Image>();
        if (imagen == null)
        {
            Debug.LogError("Este GameObject no tiene un componente Image.");
        }
    }

    public void CambiarSprite()
    {
        if (imagen != null && nuevoSprite != null)
        {
            imagen.sprite = nuevoSprite;
        }
    }
}
