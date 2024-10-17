using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolObject : MonoBehaviour
{
    public abstract void OnObjectSpawn();

    public virtual void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}
