using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpeedCheckScript : MonoBehaviour {
    

	void OnTriggerEnter(Collider collider)
	{
        GameObject player = collider.transform.root.gameObject;
        if (player.tag == "Player") //confirmation that this is the player
        {
            CarController carControl = player.GetComponent<CarController>();
			if (carControl.getSpeed() >= carControl.tapSpeed * 0.9f) //player crashed through wall at high speed
			{
                gameObject.SetActive(false);
                carControl.playBreakthroughSound();
                carControl.increaseScoreCall(1);
			}
			else //player crashed at slow speed
			{
                carControl.endGameWallCrash();

			}
		}
	}
}
