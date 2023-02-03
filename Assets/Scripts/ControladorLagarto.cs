using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that contains the details of the Lagarto character
/// </summary>

[AddComponentMenu("Aventura_Trófica/ControladorLagarto")]
public class ControladorLagarto : CharacterControllerParent
{
    public static ControladorLagarto instance;

    private void Awake()
    {
        instance = this;
    }
    public ControladorLagarto(CharacterController _controller, float _speed, float _gravity)
       : base(_controller, _speed, _gravity)
    {

    }

    public override void Fly() { }

}
