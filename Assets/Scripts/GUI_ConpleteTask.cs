using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_ConpleteTask : MonoBehaviour, ICompletedTask
{
    [SerializeField]
    private UnityEngine.UI.Button Btn_Request;
    [SerializeField]
    private GUIPrint_TournametsData _PrintData;
    [SerializeField]
    private RectTransform ExitButton;
    public void OnCompletedTask()
    {
        Btn_Request.interactable = false;
        LeanTween.scale(ExitButton, Vector3.one, .2f).setEaseInCirc();
        _PrintData.UI_CallPrintData();
    }
    public void UI_ExitButton()
    {
        Application.Quit();
    }
}
