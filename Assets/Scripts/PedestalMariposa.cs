using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalMariposa : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "CharacterGusano")
        {
            GoToMariposa();
        }
    }

    private void GoToMariposa()
    {

    }
}
