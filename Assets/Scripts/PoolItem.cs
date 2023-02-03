using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to reference Pool's items
/// </summary>
[AddComponentMenu("Aventura_Trófica/PoolItem")]
public class PoolItem : MonoBehaviour
{
    public GameObject prefab;
    public int amount;
    // Variable used to know if the list is to be broaden during execution time
    public bool expandable;
}
