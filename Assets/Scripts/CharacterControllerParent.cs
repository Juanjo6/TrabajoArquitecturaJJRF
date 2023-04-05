using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class parent to all the characters, containing shared functionality
/// </summary>

[AddComponentMenu("Aventura_Tr�fica/CharacterControllerParent")]
public abstract class CharacterControllerParent : MonoBehaviour
{
	//Parameters
	public CharacterController controller;

	public float speed = 6.0F;	// Esto pasarlo a cada hijo en concreto.
	public float gravity = 20.0F;
	public bool personajeActivo = false;
	protected float truncateNumber = 0.1f;
	protected float zero = 0f;
	[SerializeField] protected float impulse;

	// Camera
	public Transform piv_Cam;

	// Animation
	public Animator animator;

	// Internal management of the movement
	protected Vector3 moveDirection = Vector3.zero;

	// Constructor used to initialize this class' instances
    public CharacterControllerParent (CharacterController _controller, float _speed, float _gravity)
    {
    	controller = _controller;
    	speed = _speed;
    	gravity = _gravity;
    }

	// Methods used to activate characters abilities
	public abstract void Special1();
	public abstract void Special2();
}
