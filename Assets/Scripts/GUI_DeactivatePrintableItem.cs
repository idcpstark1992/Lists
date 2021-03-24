using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_DeactivatePrintableItem : MonoBehaviour
{
    private void OnEnable()
    {

        GUIPrint_TournametsData.Listener_DeactivateItems += OnDeactivateItem;
    }
    private void OnDisable()
    {
        GUIPrint_TournametsData.Listener_DeactivateItems -= OnDeactivateItem;
    }


    private void OnDeactivateItem()
    {
        gameObject.SetActive(false);
    }

}
