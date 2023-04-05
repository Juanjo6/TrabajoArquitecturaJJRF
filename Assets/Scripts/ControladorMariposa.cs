using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that contains the details of the Mariposa character
/// </summary>

[AddComponentMenu("Aventura_Trófica/ControladorMariposa")]
public class ControladorMariposa : CharacterControllerParent
{
    public static ControladorMariposa instance;

    private void Awake()
    {
        instance = this;
    }

    public ControladorMariposa(CharacterController _controller, float _speed, float _gravity)
        : base(_controller, _speed, _gravity)
    {

    }

	private void Update()
	{
		if (personajeActivo == true)
		{
			Vector3 tempDirection = piv_Cam.TransformDirection(
						new Vector3(SimpleInput.GetAxis("Horizontal"), zero, SimpleInput.GetAxis("Vertical"))) * speed;

			// Debug.Log("is grounded");
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
			if (tempDirection.magnitude > truncateNumber)
			{
				transform.forward = tempDirection.normalized;
			}

			//APLICO MOVIMIENTO
			controller.Move(moveDirection * Time.deltaTime);
		}
	}

	// Makes the Mariposa go up a certain amount
	public override void Special1()
    {
        moveDirection.y = impulse;
    }
	public override void Special2() { }
}
