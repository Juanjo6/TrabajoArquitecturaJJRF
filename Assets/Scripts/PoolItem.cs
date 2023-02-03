using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to reference Pool's items
/// </summary>

[AddComponentMenu("Aventura_Trófica/PoolItem")]
[System.Serializable] // To be able to add them via inspector
public class PoolItem // It seems it can not inherit form MonoBehaviour and be recognized as a valid parameter at the same time
{
    public GameObject prefab;
    public int amount;
    // Variable used to know if the list is to be broaden during execution time
    public bool expandable;
}
