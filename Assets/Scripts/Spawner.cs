using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A simple class used to add force to a projectile
/// </summary>
public class Spawner : MonoBehaviour
{
    public static Spawner singleton;

    public GameObject projectile;
    public bool isListExpandible;

    private void Awake()
    {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Pool.singleton.items != null && Pool.singleton.items.Count > 0)
        {
            foreach (PoolItem item in Pool.singleton.items)
            {
                if (item.prefab.CompareTag("Bola"))
                {
                    isListExpandible = item.expandable;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
