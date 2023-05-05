using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditionRana : MonoBehaviour
{
    public static WinConditionRana instance;

    public bool winConditionRana;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "CharacterRana")
        {
            winConditionRana = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CharacterRana")
        {
            winConditionRana = false;
        }
    }
}
