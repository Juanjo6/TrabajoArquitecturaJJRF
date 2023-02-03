using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [field: SerializeField] private GameObject pivoteCamara1;
    [field: SerializeField] private GameObject pivoteCamara2;
    [field: SerializeField] private GameObject pivoteCamara3;
    [field: SerializeField] private GameObject pivoteCamara4;
    [field: SerializeField] private GameObject character1;
    [field: SerializeField] private GameObject character2;
    [field: SerializeField] private GameObject character3;
    [field: SerializeField] private GameObject character4;

    public void DisplayCamera1()
    {
        character1.GetComponentInChildren<ControladorGusano>().personajeActivo = true;
        character2.GetComponentInChildren<ControladorRana>().personajeActivo = false;
        character3.GetComponentInChildren<ControladorLagarto>().personajeActivo = false;
        character4.GetComponentInChildren<ControladorMariposa>().personajeActivo = false;
    }
    public void DisplayCamera2()
    {
        character2.GetComponentInChildren<ControladorRana>().personajeActivo = true;
        character1.GetComponentInChildren<ControladorGusano>().personajeActivo = false;
        character3.GetComponentInChildren<ControladorLagarto>().personajeActivo = false;
        character4.GetComponentInChildren<ControladorMariposa>().personajeActivo = false;

    }
    public void DisplayCamera3()
    {
        character3.GetComponentInChildren<ControladorLagarto>().personajeActivo = true;
        character1.GetComponentInChildren<ControladorGusano>().personajeActivo = false;
        character2.GetComponentInChildren<ControladorRana>().personajeActivo = false;
        character4.GetComponentInChildren<ControladorMariposa>().personajeActivo = false;
    }
    public void DisplayCamera4()
    {
        character4.GetComponentInChildren<ControladorMariposa>().personajeActivo = true;
        character1.GetComponentInChildren<ControladorGusano>().personajeActivo = false;
        character2.GetComponentInChildren<ControladorRana>().personajeActivo = false;
        character3.GetComponentInChildren<ControladorLagarto>().personajeActivo = false;
    }
}
