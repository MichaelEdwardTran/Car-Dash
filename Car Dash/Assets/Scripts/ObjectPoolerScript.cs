using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolerScript : MonoBehaviour
{

    public GameObject pooledObject;

    public int pooledAmount = 5;

    public Transform levelObjectParentTransform;

    List<GameObject> pooledObjects;

    // Use this for initialization
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject, levelObjectParentTransform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject getPooledObject()
    {
        for(int i = 0; i < pooledObjects.Count; i++) //search through the pool
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        //if we couldn't find an unused object, make one

        GameObject obj = (GameObject)Instantiate(pooledObject, levelObjectParentTransform);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        Debug.Log("Created new object to add to pool");
        return obj;

    }
}
