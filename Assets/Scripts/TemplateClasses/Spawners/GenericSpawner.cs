using UnityEngine;

public class GenericSpawner<TPool, TObject> : MonoBehaviour
    where TPool : GenericPool<TObject>
    where TObject : SpawnObject
{
    [SerializeField] protected TPool PoolObjects;

    public TObject Spawn()
    {
        return PoolObjects.GetObject();
    }

    public void Reset()
    {
        PoolObjects.Reset();
    }
}
