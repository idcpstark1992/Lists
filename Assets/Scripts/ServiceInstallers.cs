using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceInstallers : MonoBehaviour
{
    [SerializeField]
    [Header("Instalador para La Interfaz de Obtener los objetos que vienen del servidor")]
    private GetTournaments _IGetFetchedDataSource;
    [Header("Instalador para la interfaz de la ventana modal")]
    [SerializeField]
    private GUI_ModalScreen _IModalScreen;
    [SerializeField]
    private GUI_ConpleteTask _ICompletedTask;
    private void Start()
    {
        ServiceLocator.Instance.AddService<IGetFetchedData>(_IGetFetchedDataSource);
        ServiceLocator.Instance.AddService<IModalScreen>(_IModalScreen);
        ServiceLocator.Instance.AddService<ICompletedTask>(_ICompletedTask);
    }
}
