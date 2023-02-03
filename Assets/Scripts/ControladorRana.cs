using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that contains the details of the Rana character
/// </summary>

[AddComponentMenu("Aventura_Trófica/ControladorRana")]
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
