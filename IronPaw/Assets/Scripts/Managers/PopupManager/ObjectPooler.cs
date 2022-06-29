using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPooler<T> : MonoBehaviour  where T  : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] private int amountToPool = 20;

    internal List<T> pooledObjects = new List<T>();

    private void Start()
    {
        Init();
    }
    public void Init()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(_prefabToSpawn, transform);
            obj.SetActive(false);
            pooledObjects.Add(obj.GetComponent<T>());
        }
    }
    
    public T GetPooledObjects()
    {
        foreach (var item in pooledObjects)
        {
            if (!item.gameObject.activeSelf)
            {
                return item;
            }
        }
        return null;
    }
}
