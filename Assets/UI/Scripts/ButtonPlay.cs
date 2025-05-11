using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonPlay : MonoBehaviour
{
    public GameObject PanelMenu;
    public Button PlayBtn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0;
        PlayBtn.onClick.AddListener(Play);
    }
    void Play ()
    {
        Time.timeScale = 1;
        PanelMenu.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
