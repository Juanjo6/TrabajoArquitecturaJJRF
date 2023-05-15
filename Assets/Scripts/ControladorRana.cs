using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that contains the details of the Rana character
/// </summary>

[AddComponentMenu("Aventura_Trófica/ControladorRana")]
public class ControladorRana : CharacterControllerParent
{
    public static ControladorRana instance;

	public short Yspeed;

	private void Awake()
    {
        instance = this;
    }
    public ControladorRana(CharacterController _controller, float _speed, float _gravity)
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
					moveDirection.y -= gravity * Time.deltaTime;
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
		if (personajeActivo == false)
		{
				if (!controller.isGrounded)
				{
					gravedad.y -= gravity * Time.deltaTime;
					controller.Move(gravedad * Time.deltaTime);
				}
		}
	}

	public override void Special1() 
	{
		if (this.controller.isGrounded)
		{
			Yspeed = 1;

			moveDirection.y = impulse;
		}
	}
}
