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
	public PlayerRodControl rodControl;
	public ValueOfFish valueOfFish;
	public GameObject textParticlePrefab;

	private void Start ()
	{
		if(scoreDisplay)
			scoreDisplay.text = score.ToString () + "/" + goalThreshold.threshhold;
	}

	public void AddPoint() {
		int point = valueOfFish.pointToAdd;
		valueOfFish.pointToAdd = 0;

        score += point;
		if (scoreDisplay)
			scoreDisplay.text = score.ToString () + "/" + goalThreshold.threshhold;
		collectFishSound.Play ();
		textParticlePrefab.GetComponentInChildren<Text> ().text = "+" + point;
		textParticleSpawner.SpawnObject ();
	}

    public int GetScore() {
        return score;
    }

	public void SetScore(int score) {
		this.score = score;
	}
}
