using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPoolObject : MonoBehaviour
{
    public GameObject pooledObject;
    public int poolSize;
    private List<GameObject> pool;

    private void Awake()
    {
        pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pool.Add(obj);
        }
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

        return null;
    }
}
