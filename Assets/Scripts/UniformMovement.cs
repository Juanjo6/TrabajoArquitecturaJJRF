using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *Looping the object transform across a rectangle area
*/
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
            this.gameObject.SetActive(false);
    }
}
