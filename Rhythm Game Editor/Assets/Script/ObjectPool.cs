using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private Poolable poolObj;

    public Poolable[] Grid;
    [SerializeField]
    private Stack<Poolable> poolStack = new Stack<Poolable>();

    private void Start()
    {
        GridAdd();
    }
    public void GridAdd()
    {
        for (int i = 0; i < Grid.Length; i++)
        {
            Poolable Obj = Grid[i];
            poolStack.Push(Obj);
        }
    }
    public GameObject Pop()
    {
        Poolable obj = poolStack.Pop();
        obj.gameObject.SetActive(true);
        return obj.gameObject;
    }

    public void Push(Poolable obj)
    {
        obj.gameObject.SetActive(false);
        poolStack.Push(obj);
    }
}
