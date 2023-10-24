using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    public GameObject ObjectPrefab;
    private Stack<GameObject> _pool = new Stack<GameObject>();

    public GameObject GetGameObjectFromPool()
    {
        if (_pool.Count > 0)
        {
            return _pool.Pop();
        }
        return CreateNewGameObject();
    }

    public GameObject CreateNewGameObject()
    {
        GameObject clone = GameObject.Instantiate(ObjectPrefab);
        clone.transform.name = ObjectPrefab.name;
        if (!clone.TryGetComponent(out ReturnGameObjectToPool component))
        {
            component = clone.AddComponent<ReturnGameObjectToPool>();
            component.ObjectPool = this;
        }
        return clone;
    }

    public void ReturnGameObjectToPool(GameObject gameObject)
    {
        _pool.Push(gameObject);
    }

}
