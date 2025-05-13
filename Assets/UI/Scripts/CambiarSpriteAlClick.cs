using UnityEngine;
using UnityEngine.UI;
using TMPro; // <-- Importante para usar TextMeshProUGUI

public class CambiarSpriteAlClick : MonoBehaviour
{
    public Sprite nuevoSprite;
    public Sprite noDisponibleSprite;
    public TextMeshProUGUI contadorTexto; // <-- Cambiado a TMP

    private Image imagen;
    private int contador = 5;

    void Start()
    {
        imagen = GetComponent<Image>();
        if (imagen == null)
        {
            Debug.LogError("Este GameObject no tiene un componente Image.");
        }

        if (contadorTexto != null)
        {
            contadorTexto.text = contador.ToString();
        }
    }

    public void CambiarSprite()
    {
        if (contador > 0)
        {
            contador--;
            contadorTexto.text = contador.ToString();

            if (contador == 0)
            {
                imagen.sprite = noDisponibleSprite;
            }
            else
            {
                imagen.sprite = nuevoSprite;
            }
        }
    }
}