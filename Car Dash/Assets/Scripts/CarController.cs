using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
    public GameObject playerCharacterPrefab;
    public GameObject EndGameMenu;
    public AudioSource engineRevSound;
    public AudioSource wallBreakthroughSound;
    public AudioSource wallCrashSound;
    public AudioSource policeSound;
    public EngineSoundScript engineSound;

    private GameObject currentCar;

	public float normalSpeed = 30;
	public float tapSpeed = 50;
	public float drag = 1; //drag is 0 when at tapSpeed or normalSpeed, when the player is above normal speed and doesnt tap, drag is the set value

	private bool started = false;
	public Rigidbody rb;

	private float velocity = 0;
    private bool isRevvingUp = false;

    public GameObject scoreMesh;

    void Start () {
        rb = GetComponent<Rigidbody>();
		rb.velocity = Vector3.zero;
		rb.drag = 0;


        playerCharacterPrefab = Resources.Load("PlayerCharacters/CompactGreen") as GameObject;
        currentCar = Instantiate(playerCharacterPrefab, gameObject.transform) as GameObject;
        currentCar.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        if (started)
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            if (Input.GetButton("Fire1"))
            {
                speedUp();
            }
            else
            {
                slowDown();
            }

#else //mobile
			if(Input.touchCount > 0)
			{
				speedUp();
			}
			else
			{
				slowDown();
			}
			
#endif
            if (rb.drag == drag && rb.velocity.x < normalSpeed) //if we are slowing down, but we're going slower than the min speed
            {
                rb.drag = 0; //stop slowing down
                rb.velocity = new Vector3(normalSpeed, 0, 0); //set velocity to min speed
            }
        }
	}
	void LateUpdate()
	{
		velocity = rb.velocity.x; //so other scripts can figure out our velocity
	}

	public void startGame()
	{
		started = true;
	}

	public float getSpeed()
	{
		return velocity;
	}

    private void speedUp()
    {
        rb.velocity = new Vector3(tapSpeed, 0, 0);
        rb.drag = 0;
        if(!isRevvingUp)
        {
            engineRevSound.volume = 1;
            engineRevSound.Play();
            isRevvingUp = true;
        }
    }

    private void slowDown()
    {
        rb.drag = drag;
        isRevvingUp = false;
        engineRevSound.volume = 0.7f;

    }

    public void increaseScoreCall(int amount)
    {
        scoreMesh.GetComponent<ScoreUpdaterScript>().increaseScore(amount); //sends a call to ScoreUpdaterScript to increase score by amount
    }

    public void setScoreCall(int amount)
    {
        scoreMesh.GetComponent<ScoreUpdaterScript>().setScore(amount); //sends a call to ScoreUpdaterScript to set score to amount
    }

    public void playBreakthroughSound()
    {
        wallBreakthroughSound.Play();
    }

    public void endGameWallCrash()
    {
        //TODO: crashed car effects/prefab
        wallCrashSound.Play();
        endGameGeneric();
        rb.velocity = new Vector3(0, 0, 0);
    }
    public void endGamePoliceSpeeding()
    {
        // TODO: lights
        policeSound.Play();
        endGameGeneric();
        rb.drag = 5;
        
    }

    private void endGameGeneric()
    {
        started = false;
        engineRevSound.Stop();
        engineSound.stopAll();
        EndGameMenu.SetActive(true);
        saveScore();
    }
    //if current score is higher than current high score, save the score in player preferences "highScore"
    private void saveScore()
    {
        int score = scoreMesh.GetComponent<ScoreUpdaterScript>().getScore();
        if (score > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", score);
            scoreMesh.GetComponent<ScoreUpdaterScript>().setText("New High Score: ");
        }
       
    }

}
