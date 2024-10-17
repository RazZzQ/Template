using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObjectPooling : MonoBehaviour
{
    public GameObject pooledObject;
    public int initialPoolSize;
    private List<GameObject> pool;

    private void Awake()
    {
        pool = new List<GameObject>();

        for (int i = 0; i < initialPoolSize; i++)
        {
            AddObjectToPool();
        }
    }

    private void AddObjectToPool()
    {
        GameObject obj = Instantiate(pooledObject);
        obj.SetActive(false);
        pool.Add(obj);
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        AddObjectToPool();
        return pool[pool.Count - 1];
    }
}
