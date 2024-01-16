using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] public bool fadein = false;
    [SerializeField] public bool fadeout = false;

    public void ShowUI()
    {
        fadein = true;
    }
    public void HideUI()
    {
        fadeout = true;
    }
    private void Update()
    {
        {
            if (fadein)
            {
                if (canvasGroup.alpha < 1)
                {
                    canvasGroup.alpha += Time.deltaTime;
                    if (canvasGroup.alpha >= 1)
                    {
                        fadein = false;
                    }
                }
            }
            if (fadeout)
            {
                if (canvasGroup.alpha >= 0)
                {
                    canvasGroup.alpha -= Time.deltaTime;
                    if (canvasGroup.alpha == 0)
                    {
                        fadeout = false;
                    }
                }
            }
        }
    }
  
    
}