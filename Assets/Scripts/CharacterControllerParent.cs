using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class parent to all the characters, containing shared functionality
/// </summary>

[AddComponentMenu("Aventura_Trófica/CharacterControllerParent")]
public abstract class CharacterControllerParent : MonoBehaviour
{
	//Parameters
	public CharacterController controller;
	public float speed = 6.0F;	// Esto pasarlo a cada hijo en concreto.
	public float gravity = 20.0F;
	public bool personajeActivo = false;
	public float flyImpulse;

	// Camera
	public Transform piv_Cam;

	// Animation
	public Animator animator;

	// Internal management of the movement
	protected Vector3 moveDirection = Vector3.zero;

	// In order to make testing
	RaycastHit hit; // Variable que guarda con lo que ha chocado el raycast
	public float raycastWallRange = 2.0f;

	// Climbing
	// What is consider a climbable wall to the character
	public LayerMask milayerWall = 6;
	public bool onWall = false;

	// Constructor used to initialize this class' instances
    public CharacterControllerParent (CharacterController _controller, float _speed, float _gravity)
    {
    	controller = _controller;
    	speed = _speed;
    	gravity = _gravity;
    }

	// Used right now to do some testing
    private void FixedUpdate()
	{
		// Comprueba si hay un muro(objeto) con esa layer con un raycast
		if (Physics.Raycast(transform.position, transform.forward, out hit, raycastWallRange, milayerWall))
		{
			// Le dice que mi pa'lante se transforma en el palante de donde da. Es para mirar de frente a las paredes siempre.
			transform.forward = -hit.normal; 
			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
			//Debug.Log("Did Hit");
			onWall = true;
		}
		else
		{
			Debug.DrawRay(transform.position, transform.forward * 1000, Color.white);
			// Debug.Log("Did not Hit");
			onWall = false;
		}
	}

	// Contains the common movement of all characters
	void Update()
	{
		if (personajeActivo == true)
        {
			Vector3 tempDirection = piv_Cam.TransformDirection(
						new Vector3(SimpleInput.GetAxis("Horizontal"), 0, SimpleInput.GetAxis("Vertical"))) * speed;
			if (!onWall)
			{
				// Movimiento en el suelo
				if (controller.isGrounded)
				{
					// Debug.Log("is grounded");
					moveDirection.x = tempDirection.x;
					moveDirection.z = tempDirection.z;
				}
				else
				{
					//Movimiento en el aire
					moveDirection.x = tempDirection.x;
					moveDirection.y -= gravity * Time.deltaTime; // Ahora mismo esto haría que cuando se cae al suelo la velocidad se conservase
					// Podría usar un math.clamp o alguna cosa para capar la gravedad
					moveDirection.z = tempDirection.z;
				}
				//ROTACION            
				if (tempDirection.magnitude > 0.1f)
				{
					transform.forward = tempDirection.normalized;
				}

			}
			//Estoy pegado a una pared y este es el comportamiento mientras estoy pegado
			// Según se desarrolle el juego, habrá que ir puliéndolo
			if (onWall)
			{
				moveDirection = transform.TransformDirection(
					new Vector3(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"), 0)) * speed;
			}

			//APLICO MOVIMIENTO
			controller.Move(moveDirection * Time.deltaTime);
		}
	}

	// Method used by some characters to fly
	public abstract void Fly();
}
