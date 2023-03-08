using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A class used to move the camera between characters
*/

[AddComponentMenu("Aventura_Trófica/CameraController")]
public class CameraController : MonoBehaviour
{
	public GameObject personaje;
	//public Transform targetWall;
	public float smoothTime;
	public float smoothRotation;

	public Transform pivoteAir;
	public Transform pivoteWall;

	//private Vector3 posicionInicialPivote = new Vector3(transform.position.x, transform.position.y, transform.position.z);

	// Usado para seguimiento atenuado de la cámara en el momento(Late) deseado
    private void LateUpdate()
    {
		//Vector3 vector3Temp = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		// Con time.deltaTime no solo hacemos más suave la transición, si no que al hacerlo en función de los frames, tiene eso en cuenta
		// también
		// El vector3Temp.position se usa para redondear y darle un buen efecto al lerp  y lo hace codependiente del movimiento en ese eje

		// Controls the camera when the character is climbing a wall
		if (ControladorGusano.instance.personajeActivo == true && ControladorGusano.instance.onWall)
		{												
			transform.position = Vector3.Lerp(transform.position, personaje.transform.position, Time.deltaTime * smoothTime);

			transform.rotation = Quaternion.Lerp(
				transform.rotation, personaje.transform.rotation, Time.deltaTime * smoothRotation);
		}
		// Controls the camera in the normal mode of the game
		if (ControladorGusano.instance.personajeActivo == true && !ControladorGusano.instance.onWall)
		{
			transform.position = Vector3.Lerp(transform.position, personaje.transform.position, Time.deltaTime * smoothTime);
			transform.rotation = Quaternion.Lerp(
				transform.rotation, pivoteAir.rotation, Time.deltaTime * smoothRotation);
		}

		if (ControladorMariposa.instance.personajeActivo == true && ControladorMariposa.instance.onWall)
		{
			transform.position = Vector3.Lerp(transform.position, personaje.transform.position, Time.deltaTime * smoothTime);

			transform.rotation = Quaternion.Lerp(
				transform.rotation, personaje.transform.rotation, Time.deltaTime * smoothRotation);
		}

		if (ControladorMariposa.instance.personajeActivo == true && !ControladorMariposa.instance.onWall)
		{
			transform.position = Vector3.Lerp(transform.position, personaje.transform.position, Time.deltaTime * smoothTime);
			transform.rotation = Quaternion.Lerp(
				transform.rotation, pivoteAir.rotation, Time.deltaTime * smoothRotation);
		}

		if (ControladorRana.instance.personajeActivo == true && ControladorRana.instance.onWall)
		{
			transform.position = Vector3.Lerp(transform.position, personaje.transform.position, Time.deltaTime * smoothTime);

			transform.rotation = Quaternion.Lerp(
				transform.rotation, personaje.transform.rotation, Time.deltaTime * smoothRotation);
		}

		if (ControladorRana.instance.personajeActivo == true && !ControladorRana.instance.onWall)
		{
			transform.position = Vector3.Lerp(transform.position, personaje.transform.position, Time.deltaTime * smoothTime);
			transform.rotation = Quaternion.Lerp(
				transform.rotation, pivoteAir.rotation, Time.deltaTime * smoothRotation);
		}
		
	}

	// Method that makes camera work for one character or another
	public void CambiarPj(GameObject newPj)
    {
		personaje = newPj;
    }
}
