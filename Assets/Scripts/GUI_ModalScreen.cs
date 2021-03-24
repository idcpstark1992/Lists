using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_ModalScreen : MonoBehaviour, IModalScreen
{
    [SerializeField]
    private RectTransform DownloadArrow;
    public void ToggleModalScreen(bool _toggle)
    {
        Vector3 mTargetScale = _toggle ? Vector3.one : Vector3.zero;
        LeanTween.scale(gameObject, mTargetScale, .2f).setEaseInOutCirc();
    }


}
