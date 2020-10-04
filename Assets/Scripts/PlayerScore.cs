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

	private void Start ()
	{
		scoreDisplay.text = score.ToString ();
	}

	public void AddPoint() {
        score++;
		scoreDisplay.text = score.ToString ();
		collectFishSound.Play ();
		textParticleSpawner.SpawnObject ();
	}

    public int GetScore() {
        return score;
    }
}
