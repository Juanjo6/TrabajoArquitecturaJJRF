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

    // Makes the Mariposa go up a certain amount
    public override void Special()
    {
        moveDirection.y = flyImpulse;
    }
}
