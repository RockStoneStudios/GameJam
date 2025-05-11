using System.Collections;
using TMPro;
using UnityEngine;

public class UIGame : MonoBehaviour
{
   public static UIGame Instance {get; private set;}
   [SerializeField] private TextMeshProUGUI messageText;

    private void Awake()
    {
        if(Instance !=null && Instance != this){
            Destroy(gameObject);
            return;
        }
       Instance = this;
       DontDestroyOnLoad(gameObject);
    }

    public void SetMessageForSeconds(string message, float time){
        StopAllCoroutines();
        StartCoroutine(ShowAndClear(message, time));

        
    }

    private IEnumerator ShowAndClear(string message,float time){
        messageText.text = message;
        yield return new WaitForSeconds(4f);
        messageText.text = "";
    }
}
