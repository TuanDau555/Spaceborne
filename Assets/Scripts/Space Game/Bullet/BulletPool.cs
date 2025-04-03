using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    public static ObjectPooler Instance;

    public List<GameObject> pooledObjects;
    public GameObject objectToPool;

    public int amountToPool;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        // Loop List, deactive them and add when Instantiate
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false); // make sure that object always deactive when started
            pooledObjects.Add(obj);
            obj.transform.SetParent(this.transform);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy) // if not active 
            {
                return pooledObjects[i];
            }
        }
        //otherwise 
        return null;
    }
}
