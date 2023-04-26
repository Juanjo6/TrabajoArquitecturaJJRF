using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalRana : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "CharacterRenacuajo")
        {
            GoToRana();
        }
    }

    private void GoToRana()
    {

    }
}
