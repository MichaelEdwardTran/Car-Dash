using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // Required when using Event data(ipointerdownhandler)

public class StartButtonScript : MonoBehaviour, IPointerDownHandler {
	public GameObject player;
	private CarController carControl;

    public GameObject scoreMesh;

	void Start()
	{
		carControl = player.GetComponent<CarController>();
    }

    public void OnPointerDown(PointerEventData eventData)
	{
		carControl.startGame ();
		this.gameObject.SetActive (false);
        scoreMesh.GetComponent<ScoreUpdaterScript>().setScore(0); //sets score to 0;
        scoreMesh.GetComponent<ScoreUpdaterScript>().setText(""); //hide the high score text

    }
}
