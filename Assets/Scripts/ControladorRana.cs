using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that contains the details of the Rana character
/// </summary>

[AddComponentMenu("Aventura_Tr�fica/ControladorRana")]
public class ControladorRana : CharacterControllerParent
{
    public static ControladorRana instance;

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
					moveDirection.y -= gravity * Time.deltaTime; // Ahora mismo esto har�a que cuando se cae al suelo la velocidad se conservase
					// Podr�a usar un math.clamp o alguna cosa para capar la gravedad
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

	public override void Special() { }

}
