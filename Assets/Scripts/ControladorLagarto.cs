using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
