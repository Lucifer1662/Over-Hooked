using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public int score;
	public Text scoreDisplay;

	private void Start ()
	{
		scoreDisplay.text = score.ToString ();
	}

	public void AddPoint() {
        score++;
		scoreDisplay.text = score.ToString ();
	}

    public int GetScore() {
        return score;
    }
}
