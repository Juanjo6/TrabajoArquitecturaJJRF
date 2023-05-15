using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that contains the details of the BlueBeetle enemy
/// </summary>

[AddComponentMenu("Aventura_Trófica/BlueBeetleController")]
public class BlueBeetleController : EnemyControllerParent
{
    public static BlueBeetleController instance;

    private void Awake()
    {
        instance = this;
    }

    public BlueBeetleController(float _speed)
    : base(_speed)
    {

    }
}