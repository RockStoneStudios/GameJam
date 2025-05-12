using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CubeCell : MonoBehaviour
{
    private Renderer cubeRenderer;
    private bool isSelected = false;
    public Color selectedColor = Color.green;
    public Color defaultColor = Color.red;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        cubeRenderer.material.color = defaultColor;
    }

    void OnMouseDown()
    {
        isSelected = !isSelected;
        cubeRenderer.material.color = isSelected ? selectedColor : defaultColor;
    }
}
