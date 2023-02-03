using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that contains the details of the Gusano character
/// </summary>

[AddComponentMenu("Aventura_Trófica/ControladorGusano")]
public class ControladorGusano : CharacterControllerParent
{
    // Como estática es que solo puede existir una, le tengo que hacer una a cada subpersonaje
    public static ControladorGusano instance;

    private void Awake()
    {
        instance = this;
    }
    public ControladorGusano(CharacterController _controller, float _speed, float _gravity)
       : base(_controller, _speed, _gravity)
    {

    }
	/*private void Update()
	{
		if (ControladorGusano.instance.personajeActivo)
		{
			Vector3 tempDirection = piv_Cam.TransformDirection(
						new Vector3(SimpleInput.GetAxis("Horizontal"), 0, SimpleInput.GetAxis("Vertical"))) * speed;
			if (!onWall)
			{
				// Movimiento en el suelo
				if (controller.isGrounded)
				{
					Debug.Log("is grounded");
					moveDirection.x = tempDirection.x;
					moveDirection.z = tempDirection.z;
				}
				else
				{
					//Movimiento en el aire
					moveDirection.x = tempDirection.x;
					moveDirection.y -= gravity * Time.deltaTime; // Ahora mismo esto haría que cuando se cae al suelo la velocidad se conservase
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
		
	}*/

    public override void Fly() { }

}
