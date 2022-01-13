using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewDayShowText : MonoBehaviour
{

     public float fadeOutTime;
    public void FadeOut()
         {
             StartCoroutine(FadeOutRoutine());
         }
         private IEnumerator FadeOutRoutine()
         { 
             Text text = GetComponent<Text>();
             Color originalColor = text.color;
             for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
             {
                 text.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t/fadeOutTime));
                 yield return null;
             }
         }
    // Start is called before the first frame update
    void Start()
    {
        FadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
