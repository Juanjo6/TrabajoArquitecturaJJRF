using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditionMariposa : MonoBehaviour
{
    public bool winConditionMariposa;

    public static WinConditionMariposa instance;
    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "CharacterMariposa")
        {
            winConditionMariposa = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CharacterMariposa")
        {
            winConditionMariposa = false;
        }
    }
}
