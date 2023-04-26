using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that contains the details of the Renacuajo character
/// </summary>

[AddComponentMenu("Aventura_Trófica/ControladorRenacuajo")]
public class ControladorRenacuajo : CharacterControllerParent
{
	// Como estática es que solo puede existir una, le tengo que hacer una a cada subpersonaje
	public static ControladorRenacuajo instance;

	// In order to make testing
	RaycastHit hit; // Variable que guarda con lo que ha chocado el raycast
	public float raycastWallRange = 1.5f;
	private float contador;

	// Climbing Waterfall
	// What is consider a climbable wall to the character
	public LayerMask milayerWall = 6;
	public bool isThereWall = false;
	public bool onWall = false;

	// Specials
	public float runningCounter;
	public float runningTime;
	public float runningSpeed;
	public float originalSpeed;
	public float runningCooldownCounter;
	public float runningCooldown;

	private void Awake()
	{
		instance = this;
	}
	public ControladorRenacuajo(CharacterController _controller, float _speed, float _gravity)
	   : base(_controller, _speed, _gravity)
	{

	}
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
			Debug.DrawRay(transform.position, transform.forward * raycastWallRange, Color.white);
			// Debug.Log("Did not Hit");
			onWall = false;
		}
	}
	private void Update()
	{
		if (personajeActivo == true)
		{
			Vector3 tempDirection = piv_Cam.TransformDirection(
						new Vector3(SimpleInput.GetAxis("Horizontal"), zero, SimpleInput.GetAxis("Vertical"))) * speed;
			if (!onWall)
			{
				// Debug.Log("is grounded");
				// Movimiento en el suelo
				if (controller.isGrounded)
				{
					// Debug.Log("is grounded");
					moveDirection.x = tempDirection.x; // En pc en diagonal se mueve a vel * sqrt(2), pero en móvil va bien.
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
				if (tempDirection.magnitude > truncateNumber)
				{
					transform.forward = tempDirection.normalized;
				}

			}
			//Estoy pegado a una pared y este es el comportamiento mientras estoy pegado
			// Según se desarrolle el juego, habrá que ir puliéndolo
			if (onWall)
			{
				moveDirection = transform.TransformDirection(
					new Vector3(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"), zero)) * speed;
			}

			//APLICO MOVIMIENTO
			controller.Move(moveDirection * Time.deltaTime);
		}
		if (runningCounter > zero)
		{
			runningCounter -= Time.deltaTime;
			if (runningCounter <= zero)
			{
				speed = originalSpeed;
				runningCooldownCounter = runningCooldown;
			}
		}
		if (runningCooldownCounter > 0)
		{
			runningCooldownCounter -= Time.deltaTime;
		}
	}

	public override void Special1()
	{
		if (runningCooldownCounter <= zero)
		{
			// anim.SetTrigger("goDash");	Variar velocidad de animación
			runningCounter = runningTime;
			originalSpeed = speed;
			speed = runningSpeed;
		}
	}
}
