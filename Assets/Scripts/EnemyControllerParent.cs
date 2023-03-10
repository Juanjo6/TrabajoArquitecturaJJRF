using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 * Class parent to all the enemies, containing shared functionality
*/

[AddComponentMenu("Aventura_Tr�fica/EnemyControllerParent")]
public class EnemyControllerParent : MonoBehaviour
{
	// Posici�n del jugador. Hace falta usarla porque es diferente de los goals del enemigo.
	public Transform posObjetivo;
	// Componente agregado a un personaje m�vil en el juego que le permite navegar la escena usando NavMesh
	public NavMeshAgent agent;
	// Parameters
	public float speed = 6.0f;

	// Variables del Raycast
	RaycastHit hit;
	public LayerMask milayerObjetivo;
	public float visionDistance;
	public float visionAngle;

	// Si CUALQUIER personaje se encuentra en frente del nps. Accesor escribir: propac + tabulador
	private bool canRaycastPlayer;
    public bool CanRaycastPlayer
	{
        get { return canRaycastPlayer; }
    }

    // What the enemy is doing
    EnemyState currentState;

	public EnemyControllerParent(float _speed)
	{
		speed = _speed;
	}
	private void FixedUpdate()
	{
		//		Debug.DrawRay(transform.position, (posObjetivo.position - transform.position), Color.red); // transform.forward * 10
		// Distincion entre rayo f�sico y dibujado
		// Comprueba si hay un muro(objeto) con esa layer con un raycast

		if (Physics.Raycast(transform.position, (posObjetivo.position - transform.position), 
			out hit, visionDistance, milayerObjetivo)) // Necesito estos para que los detecte antes que un jugador tras ellos
		{
            if (hit.collider.CompareTag("Player"))
            {
				// Debug.Log(hit.collider.CompareTag("Player"));
				Debug.Log(hit.collider);
				canRaycastPlayer = true;
			}
		}
		else
		{		
			canRaycastPlayer = false;
			//	Debug.DrawRay(transform.position, transform.forward * raycastRange, Color.white);
			//	Debug.Log("hay algo en medio o no le veo");
		}
	}

    private void Start()
    {
		// A�adir ifs para los distintos enemigos
		currentState = new EnemyMovingState(this, this.gameObject, this.posObjetivo, this.speed, this.agent);
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
