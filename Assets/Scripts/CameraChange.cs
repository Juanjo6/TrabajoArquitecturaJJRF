using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Auxiliary class that facilitates the transition of the camera between characters via buttons
*/

[AddComponentMenu("Aventura_Trófica/CameraChange")]
public class CameraChange : MonoBehaviour
{
    [field: SerializeField] private GameObject pivoteCamara1;
    [field: SerializeField] private GameObject pivoteCamara2;
    [field: SerializeField] private GameObject pivoteCamara3;
    [field: SerializeField] private GameObject character1;
    [field: SerializeField] private GameObject character2;
    [field: SerializeField] private GameObject character3;

    public void DisplayCamera1()
    {
        character1.GetComponentInChildren<ControladorGusano>().personajeActivo = true;
        character2.GetComponentInChildren<ControladorRana>().personajeActivo = false;
        character3.GetComponentInChildren<ControladorMariposa>().personajeActivo = false;
    }
    public void DisplayCamera2()
    {
        character2.GetComponentInChildren<ControladorRana>().personajeActivo = true;
        character1.GetComponentInChildren<ControladorGusano>().personajeActivo = false;
        character3.GetComponentInChildren<ControladorMariposa>().personajeActivo = false;

    }
    public void DisplayCamera4()
    {
        character3.GetComponentInChildren<ControladorMariposa>().personajeActivo = true;
        character1.GetComponentInChildren<ControladorGusano>().personajeActivo = false;
        character2.GetComponentInChildren<ControladorRana>().personajeActivo = false;
    }
}
