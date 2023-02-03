using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerParent : MonoBehaviour
{
    public float speed = 6.0F;
    public float gravity = 20.0F;

	public Transform posObjetivo;

	private void FixedUpdate()
	{
		// Distincion entre rayo físico y dibujado
		// Comprueba si hay un muro(objeto) con esa layer con un raycast
		//if (Physics.Raycast(transform.position, transform.forward, out hit, raycastRange, milayerObjetivo))
		{
			Debug.DrawRay(transform.position, (posObjetivo.position -transform.position), Color.red);
			//Debug.Log("te cogí");
		}
		//else
		{
		//	Debug.DrawRay(transform.position, transform.forward * raycastRange, Color.white);
		//	Debug.Log("hay algo en medio o no le veo");
		}
	}

	void Update()
    {
		/*
		Vector3 direction = posObjetivo.position -(transform.forward + transform.up);
		float a = Vector3.Angle(direction, transform.forward);
		Debug.Log(a);
		// Compruebo si como enemigo veo al personaje
		if (Vector3.Angle(direction, transform.forward) < 30f)
		{
			
			Debug.Log("te veo");
		}
		else Debug.Log("no te veo");
		*/
    }
}
