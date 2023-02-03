using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public override void Fly()
    {
        moveDirection.y = flyImpulse;
    }
}
