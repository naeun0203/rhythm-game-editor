using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    private static ObjectPoolManager staticInstance;
    public ObjectPool pool;
    public static ObjectPoolManager Instance()
    {
        if(staticInstance == null)
        {
            staticInstance = new ObjectPoolManager();
        }
        return staticInstance;
    }

    private void Awake()
    {
        if(staticInstance)
        {
            Destroy(gameObject);
            return;
        }
        staticInstance = this;
    }
}
