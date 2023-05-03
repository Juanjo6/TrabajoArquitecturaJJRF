using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalMariposa : MonoBehaviour
{
    public GameObject mariposaChar;
    public GameObject gusanoChar;
    public GameObject gusanoButton;
    public GameObject mariposaButton;
    public GameObject mariposaInterface;
    public GameObject gusanoInterface;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "CharacterGusano")
        {
            GoToMariposa();
        }
    }

    private void GoToMariposa()
    {
        gusanoChar.SetActive(false);
        mariposaChar.SetActive(true);
        gusanoButton.SetActive(false);
        mariposaButton.SetActive(true);
        mariposaInterface.SetActive(true);
        gusanoInterface.SetActive(false);
        CameraController.instance.CambiarPj(mariposaChar);
        CameraChange.instance.DisplayCameraMariposa3();
    }
}
