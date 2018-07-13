using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneratorChaser : MonoBehaviour {

    public List<GameObject> prefabList = new List<GameObject>();
	public Transform generationLeaderPoint;
	public float distanceBetween;


    public ObjectPoolerScript[] theObjectPools;
    private float[] platformWidths;

    // Update is called once per frame
    private void Start()
    {
        platformWidths = new float[theObjectPools.Length];
        for(int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.transform.lossyScale.x;
        }
    }

    void Update () {
		if (transform.position.x < generationLeaderPoint.position.x) //chase the leader point, and setActive a platform every jump
		{
            int platformIndex = Random.Range(0, theObjectPools.Length); //get random type of ground
            transform.position = new Vector3(transform.position.x + platformWidths[platformIndex] + distanceBetween, transform.position.y, transform.position.z);

            //Instantiate(prefabList[prefabIndex], transform.position, transform.rotation); //instantiate the random prefab

            GameObject newPlatform = theObjectPools[platformIndex].getPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
            newPlatform.transform.GetChild(0).gameObject.SetActive(true);
        }
	}
}
