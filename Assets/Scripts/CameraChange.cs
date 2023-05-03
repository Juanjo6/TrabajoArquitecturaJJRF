using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Auxiliary class that facilitates the transition of the camera between characters via buttons
*/

[AddComponentMenu("Aventura_Trófica/CameraChange")]
public class CameraChange : MonoBehaviour
{
    public static CameraChange instance;

    [field: SerializeField] private GameObject pivoteCamara1;
    [field: SerializeField] private GameObject pivoteCamara2;
    [field: SerializeField] private GameObject pivoteCamara3;
    [field: SerializeField] private GameObject pivoteCamara4;
    [field: SerializeField] private GameObject character1;
    [field: SerializeField] private GameObject character2;
    [field: SerializeField] private GameObject character3;
    [field: SerializeField] private GameObject character4;
    [field: SerializeField] private GameObject ToAirButtonSet; // Para acceder a gusano y mariposa
    [field: SerializeField] private GameObject ToWaterButtonSet; // Para acceder a renacuajo y rana

    private void Awake()
    {
        instance = this;
    }

    public void DisplayCameraGusano1()
    {
        character1.GetComponentInChildren<ControladorGusano>().personajeActivo = true;
        character2.GetComponentInChildren<ControladorRana>().personajeActivo = false;
        // character3.GetComponentInChildren<ControladorMariposa>().personajeActivo = false;
        character4.GetComponentInChildren<ControladorRenacuajo>().personajeActivo = false;

        ToWaterButtonSet.SetActive(true);
        ToAirButtonSet.SetActive(false);
    }
    public void DisplayCameraRana2()
    {
        character2.GetComponentInChildren<ControladorRana>().personajeActivo = true;
        character1.GetComponentInChildren<ControladorGusano>().personajeActivo = false;
        character3.GetComponentInChildren<ControladorMariposa>().personajeActivo = false;
        //character4.GetComponentInChildren<ControladorRenacuajo>().personajeActivo = false;

        ToAirButtonSet.SetActive(true);
        ToWaterButtonSet.SetActive(false);
    }
    public void DisplayCameraMariposa3()
    {
        character3.GetComponentInChildren<ControladorMariposa>().personajeActivo = true;
        //character1.GetComponentInChildren<ControladorGusano>().personajeActivo = false;
        character2.GetComponentInChildren<ControladorRana>().personajeActivo = false;
        character4.GetComponentInChildren<ControladorRenacuajo>().personajeActivo = false;

        ToWaterButtonSet.SetActive(true);
        ToAirButtonSet.SetActive(false);
    }
    public void DisplayCameraRenacuajo4()
    {
        character4.GetComponentInChildren<ControladorRenacuajo>().personajeActivo = true;
        character1.GetComponentInChildren<ControladorGusano>().personajeActivo = false;
        //character2.GetComponentInChildren<ControladorRana>().personajeActivo = false;
        character3.GetComponentInChildren<ControladorMariposa>().personajeActivo = false;

        ToAirButtonSet.SetActive(true);
        ToWaterButtonSet.SetActive(false);
    }
}
