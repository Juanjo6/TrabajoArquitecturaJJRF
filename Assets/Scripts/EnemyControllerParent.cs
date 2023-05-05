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
	// Posici�n del personaje. Hace falta usarla porque es diferente de los goals del enemigo.
	public Transform posGusano;
	public Transform posMariposa;
	public Transform posRenacuajo;
	public Transform posRana;
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
	protected bool canRaycastCharacterGusano;
    public bool CanRaycastCharacterGusano
	{
        get { return canRaycastCharacterGusano; }
    }

	protected bool canRaycastCharacterRana;
	public bool CanRaycastCharacterRana
	{
		get { return canRaycastCharacterRana; }
	}

	protected bool canRaycastCharacterMariposa;
	public bool CanRaycastCharacterMariposa
	{
		get { return canRaycastCharacterMariposa; }
	}

	protected bool canRaycastCharacterRenacuajo;
	public bool CanRaycastCharacterRenacuajo
	{
		get { return canRaycastCharacterRenacuajo; }
	}

	// What the enemy is doing
	protected EnemyState currentState;

	public EnemyControllerParent(float _speed)
	{
		speed = _speed;
	}
	private void FixedUpdate()
	{
		//Debug.DrawRay(transform.position, (posGusano.position - transform.position), Color.red); // transform.forward * 10
		//Debug.DrawRay(transform.position, (posRana.position - transform.position), Color.red);
		//Debug.DrawRay(transform.position, (posMariposa.position - transform.position), Color.red);
		//Debug.DrawRay(transform.position, (posRenacuajo.position - transform.position), Color.red);
		// Distincion entre rayo f�sico y dibujado
		// Comprueba si hay un muro(objeto) con esa layer con un raycast

		if (Physics.Raycast(transform.position, (posGusano.position - transform.position), 
			out hit, visionDistance, milayerObjetivo)) // Necesito estos para que los detecte antes que un jugador tras ellos
		{
            if (hit.collider.CompareTag("CharacterGusano"))
            {
				canRaycastCharacterGusano = true;
			}
		}
		else
		{
			canRaycastCharacterGusano = false;
		}

		if (Physics.Raycast(transform.position, (posRana.position - transform.position),
			out hit, visionDistance, milayerObjetivo)) // Necesito estos para que los detecte antes que un jugador tras ellos
		{
			if (hit.collider.CompareTag("CharacterRana"))
			{
				canRaycastCharacterRana = true;
			}
		}
		else
		{
			canRaycastCharacterRana = false;
		}
		if (Physics.Raycast(transform.position, (posMariposa.position - transform.position),
			out hit, visionDistance, milayerObjetivo)) // Necesito estos para que los detecte antes que un jugador tras ellos
		{
			
			if (hit.collider.CompareTag("CharacterMariposa"))
			{
				
				canRaycastCharacterMariposa = true;
			}
		}
		else
		{
			canRaycastCharacterMariposa = false;
		}

		if (Physics.Raycast(transform.position, (posRenacuajo.position - transform.position),
			out hit, visionDistance, milayerObjetivo)) // Necesito estos para que los detecte antes que un jugador tras ellos
		{
			if (hit.collider.CompareTag("CharacterRenacuajo"))
			{
				canRaycastCharacterRenacuajo = true;
			}
		}
		else
		{
			canRaycastCharacterRenacuajo = false;
		}
	}

    private void Start()
    {
		// A�adir ifs para los distintos enemigos
		currentState = new EnemyMovingState(this, this.gameObject, this.posGusano, posMariposa, this.posRana,
			posRenacuajo, this.speed, this.agent);
	}

	private void Update()
	{
		currentState = currentState.Process();
	}
}
