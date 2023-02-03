using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class parent to all the enemies, containing shared functionality
*/

[AddComponentMenu("Aventura_Trófica/EnemyControllerParent")]
public class EnemyControllerParent : MonoBehaviour
{
	// Parameters
	public float speed = 6.0F;
    public float gravity = 20.0F;

	// Target
	public Transform posObjetivo;

	// What the enemy is doing
	EnemyState currentState;

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

    private void Start()
    {
		currentState = new EnemyIdleState(this.gameObject, this.posObjetivo);
	}
    void Update()
    {
		currentState = currentState.Process();
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
