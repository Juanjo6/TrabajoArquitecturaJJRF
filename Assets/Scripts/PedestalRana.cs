using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalRana : MonoBehaviour
{
    public GameObject ranaChar;
    public GameObject renacuajoChar;
    public GameObject renacuajoButton;
    public GameObject ranaButton;
    public GameObject ranaInterface;
    public GameObject renacuajoInterface;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CharacterRenacuajo")
        {
            GoToRana();
        }
    }

    private void GoToRana()
    {
        renacuajoChar.SetActive(false);
        ranaChar.SetActive(true);
        renacuajoButton.SetActive(false);
        ranaButton.SetActive(true);
        ranaInterface.SetActive(true);
        renacuajoInterface.SetActive(false);
        CameraController.instance.CambiarPj(ranaChar);
        CameraChange.instance.DisplayCameraRana2();
    }
}
