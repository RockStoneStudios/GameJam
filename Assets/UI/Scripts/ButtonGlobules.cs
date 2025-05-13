using UnityEngine;
using UnityEngine.UI;

public class ButtonGlobules : MonoBehaviour
{
    public Button buttonCañon;
    public Button buttonEscudo;
    public Button buttonLuchon;
    public Button buttonBola;
    public Button buttonHuvito;
    

    
    private Image imagenButton;
    private bool alternado = false;
    private Button selectedButton;
    private Color defaultColor  = Color.white;
    private Color selectedColor = Color.red;

    // Start is called once before the first execution of Update after the MonoBehaviour is created


   void Start()
{
    buttonCañon.onClick.AddListener(() => onButtonClick(buttonCañon, "cañon"));
    buttonEscudo.onClick.AddListener(() => onButtonClick(buttonEscudo, "Escudo"));
    buttonLuchon.onClick.AddListener(() => onButtonClick(buttonLuchon, "luchon"));
    buttonBola.onClick.AddListener(() => onButtonClick(buttonBola, "Bola"));
    buttonHuvito.onClick.AddListener(() => onButtonClick(buttonHuvito, "Huevito"));
}
    // Update is called once per frame
    void Update()
    {

    }

    void onButtonClick(Button clickedButton, string name)
    {
        Debug.Log(name);
        if (selectedButton != null)
        {
            setButtonColor(selectedButton, defaultColor);
        }

        // Set the new selected button and color it
        selectedButton = clickedButton;
        setButtonColor(selectedButton, selectedColor);

    }

    void setButtonColor(Button button, Color color)
    {
        // This sets the button's Image component color
        var image = button.GetComponent<Image>();
        if (image != null)
        {
            image.color = color;
        }
    }

    
    
}
