using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public int score;
	public Text scoreDisplay;
	public AudioSource collectFishSound;
	public SpawnGameObject textParticleSpawner;
	public IfPlayerScore goalThreshold;

	private void Start ()
	{
		scoreDisplay.text = score.ToString () + "/" + goalThreshold.threshhold;
	}

	public void AddPoint() {
        score++;
		scoreDisplay.text = score.ToString () + "/" + goalThreshold.threshhold;
		collectFishSound.Play ();
		textParticleSpawner.SpawnObject ();
	}

    public int GetScore() {
        return score;
    }
}
