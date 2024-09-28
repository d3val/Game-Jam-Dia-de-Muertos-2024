using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpUI : MonoBehaviour
{
    [SerializeField] GameObject gameObjectUI;
    [SerializeField] bool startMinimize;

    private Vector3 originScales;

    private void Start()
    {
        originScales = gameObjectUI.transform.localScale;
        if(startMinimize)
        {
            gameObjectUI.transform.localScale = Vector3.zero;
        }
    }

    public void ShowPopUp()
    {
        LeanTween.scale(gameObjectUI, originScales, 0.5f).setEase(LeanTweenType.easeOutBack);
    }

    public void HidePopUp()
    {
        LeanTween.scale(gameObjectUI, Vector3.zero, 0.5f).setEase(LeanTweenType.easeInBack);
    }
}
