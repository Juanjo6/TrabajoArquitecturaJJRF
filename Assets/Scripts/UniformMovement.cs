using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A simple class used to add force to a projectile
/// </summary>
[AddComponentMenu("Aventura_Trófica/UniformMovement")]
public class UniformMovement : MonoBehaviour
{
    public Vector3 velocity;

    void Update()
    {
        this.transform.Translate(velocity * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Asset")
        {
            this.gameObject.SetActive(false);
        }
    }
}
