using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A simple class used to add force to a projectile
/// </summary>

[AddComponentMenu("Aventura_Tr�fica/Spawner")]
public class Spawner : MonoBehaviour
{
    public static Spawner singleton;

    public GameObject projectile;
    public bool isListExpandible;
    public Transform spawnerPosition;

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

    // Method used to shooting
    public void Shooting()
    {
        // Chances of shooting
        if (Random.Range(0, 100) < 1)
        {
            // Creamos una referencia al objeto que queremos usar
            GameObject ball = Pool.singleton.Get("Bola");
            // If the reference is full
            if (ball != null)
            {
                // Creater ball in the spawner
                ball.transform.position = this.transform.position;
                ball.SetActive(true);
            }
            else if (isListExpandible)
            {
                Pool.singleton.AddInstanceToList(Instantiate(this.projectile, new Vector3(spawnerPosition.position.x,
                    spawnerPosition.position.y, spawnerPosition.position.z), Quaternion.identity));
            }
        }
    }
}
