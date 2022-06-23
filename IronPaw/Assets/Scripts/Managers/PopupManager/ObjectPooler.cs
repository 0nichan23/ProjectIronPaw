using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private int amountToPool = 20;

    internal List<GameObject> pooledObjects = new List<GameObject>();

    private void Start()
    {
        Init();
    }
    public void Init()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(BulletPrefab, transform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }
    
    public GameObject GetPooledObjects()
    {
        return pooledObjects.Where(x => !x.activeInHierarchy).First<GameObject>();
    }
}
