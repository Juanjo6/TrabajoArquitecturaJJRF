using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "CharacterRana")
        {
            //RanaHealthController.instance.DealWithDamage();
        }
        if (collision.collider.tag == "CharacterGusano")
        {
            GusanoHealthController.instance.DealWithDamage();
        }
        if (collision.collider.tag == "CharacterRana")
        {
            //RanaHealthController.instance.DealWithDamage();
        }
    }
}
