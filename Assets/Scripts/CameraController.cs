using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject personaje;
	//public Transform targetWall;
	public float smoothTime;
	public float smoothRotation;

	public Transform pivoteAir;
	public Transform pivoteWall;

	//private Vector3 posicionInicialPivote = new Vector3(transform.position.x, transform.position.y, transform.position.z);

	// Usado para seguimiento atenuado de la c�mara en el momento(Late) deseado
    private void LateUpdate()
    {
		//Vector3 vector3Temp = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		// Con time.deltaTime no solo hacemos m�s suave la transici�n, si no que al hacerlo en funci�n de los frames, tiene eso en cuenta
		// tambi�n
		// El vector3Temp.position se usa para redondear y darle un buen efecto al lerp  y lo hace codependiente del movimiento en ese eje

		// Controla la c�mara cuando se est� trepando
		if (ControladorGusano.instance.personajeActivo == true && ControladorGusano.instance.onWall)
		{												
			transform.position = Vector3.Lerp(transform.position, personaje.transform.position, Time.deltaTime * smoothTime);

			transform.rotation = Quaternion.Lerp(
				transform.rotation, personaje.transform.rotation, Time.deltaTime * smoothRotation);
		}
		// Controla la c�mara del modo normal del juego
		if (ControladorGusano.instance.personajeActivo == true && !ControladorGusano.instance.onWall)
		{
			transform.position = Vector3.Lerp(transform.position, personaje.transform.position, Time.deltaTime * smoothTime);
			transform.rotation = Quaternion.Lerp(
				transform.rotation, pivoteAir.rotation, Time.deltaTime * smoothRotation);
		}
		
		if (ControladorLagarto.instance.personajeActivo == true && ControladorLagarto.instance.onWall)
		{
			transform.position = Vector3.Lerp(transform.position, personaje.transform.position, Time.deltaTime * smoothTime);

			transform.rotation = Quaternion.Lerp(
				transform.rotation, personaje.transform.rotation, Time.deltaTime * smoothRotation);
		}
		if (ControladorLagarto.instance.personajeActivo == true && !ControladorLagarto.instance.onWall)
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
		// Controla la c�mara del modo normal del juego
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
		// Controla la c�mara del modo normal del juego
		if (ControladorRana.instance.personajeActivo == true && !ControladorRana.instance.onWall)
		{
			transform.position = Vector3.Lerp(transform.position, personaje.transform.position, Time.deltaTime * smoothTime);
			transform.rotation = Quaternion.Lerp(
				transform.rotation, pivoteAir.rotation, Time.deltaTime * smoothRotation);
		}
		
	}

	public void CambiarPj(GameObject newPj)
    {
		personaje = newPj;
		// transform.position = newPj.transform.position;
    }
}
