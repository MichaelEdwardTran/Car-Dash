using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdaterScript : MonoBehaviour {

    private TextMeshProUGUI scoreMesh;
    private int score;
    private string preScoreText = "High Score: ";
	// Use this for initialization
	void Start () {
        scoreMesh = GetComponent<TextMeshProUGUI>();
        score = PlayerPrefs.GetInt("highScore");
	}
	
	// Update is called once per frame
	void Update () {
        scoreMesh.text = preScoreText + score.ToString();
	}

    //public function to be called by others to increase score
    public void increaseScore(int amount)
    {
        score += amount;
    }
    //public function to be called by others to set score
    public void setScore(int amount)
    {
        score = amount;
    }

    //returns the current score
    public int getScore()
    {
        return score;
    }

    //Sets the Score Text
    public void setText(string text)
    {
        preScoreText = text;
    }
}
