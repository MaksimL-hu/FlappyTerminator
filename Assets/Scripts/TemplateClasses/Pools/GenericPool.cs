using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GenericPool<TGameObject> : MonoBehaviour where TGameObject : SpawnObject
{
    [SerializeField] protected TGameObject Prefab;
    [SerializeField] protected Transform Container;

    protected ObjectPool<TGameObject> Pool;
    protected List<TGameObject> CreatedObjects;

    protected virtual void Awake()
    {
        CreatedObjects = new List<TGameObject>();
        Pool = new ObjectPool<TGameObject>(
            createFunc: () => InstantiateObject(),
            actionOnRelease: (@object) => OnActionRelease(@object),
            actionOnDestroy: (@object) => DestroyObject(@object));
    }

    protected virtual TGameObject InstantiateObject()
    {
        TGameObject gameObject = Instantiate(Prefab);
        gameObject.transform.parent = Container;
        CreatedObjects.Add(gameObject);

        return gameObject;
    }

    protected virtual void OnActionRelease(TGameObject gameObject)
    {
        gameObject.gameObject.SetActive(false);
    }

    protected virtual void ReleaseObject(TGameObject gameObject)
    {
        Pool.Release(gameObject);
    }

    protected virtual void DestroyObject(TGameObject gameObject)
    {
        Destroy(gameObject);
    }

    public virtual TGameObject GetObject()
    {
        return Pool.Get();
    }

    public virtual void Reset()
    {
        foreach (TGameObject gameObject in CreatedObjects)
        {
            if (gameObject.gameObject.activeSelf)
            {
                ReleaseObject(gameObject);
            }
        }
    }
}