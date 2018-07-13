using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerWallScript : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("GroundPlatform"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
