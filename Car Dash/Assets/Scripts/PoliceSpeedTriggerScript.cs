using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpeedTriggerScript : MonoBehaviour {
    private CarController carControl;
    private GameObject player;
    private bool caughtByThePolice = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject.tag == "Player") 
        {
            player = other.transform.root.gameObject;
            carControl = player.GetComponent<CarController>();
            if (carControl.getSpeed() >= carControl.tapSpeed * 0.9f)
            {
                carControl.endGamePoliceSpeeding();
                caughtByThePolice = true;
            }
            if(!caughtByThePolice)
            {
                carControl.increaseScoreCall(1);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (carControl.getSpeed() >= carControl.tapSpeed * 0.9f)
        {
            carControl.endGamePoliceSpeeding();
        }
    }
    
}
