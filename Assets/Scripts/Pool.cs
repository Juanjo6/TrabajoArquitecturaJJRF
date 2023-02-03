using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class of objects that will be initialized waiting to be used, rather than being creating and destroying them
/// </summary>
[AddComponentMenu("Aventura_Trófica/Pool")]
//[System.Serializable]
public class Pool : MonoBehaviour
{
    public static Pool singleton;

    public List<PoolItem> items;
    public List<GameObject> pooledItems;

    private void Awake()
    {
        singleton = this;
    }

    void Start()
    {
        pooledItems = new List<GameObject>();
        foreach (PoolItem item in items)
        {         
            for (int i = 0; i < item.amount; i++)
            {
                GameObject obj = Instantiate(item.prefab);

                obj.SetActive(false);

                pooledItems.Add(obj);
            }
        }
    }
    public GameObject Get(string tag)
    {
        for (int i = 0; i < pooledItems.Count; i++)
        {
            if (!pooledItems[i].activeInHierarchy && pooledItems[i].CompareTag(tag))
            {
                return pooledItems[i];
            }
        }
        return null;
    }

    public void AddInstanceToList(GameObject pooledItem)
    {
        pooledItems.Add(pooledItem);
    }
}
