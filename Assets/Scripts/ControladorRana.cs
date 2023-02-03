using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public override void Fly() { }

}
