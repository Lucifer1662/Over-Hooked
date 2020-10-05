using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class TimerHitZeroEvent : UnityEvent { }

// Attach me to the textbox you want to display the timer!
public class Timer : MonoBehaviour
{
	public float timeLeft; // in seconds
	private Text textBox;
	private int prevMin;
	private int prevSec;
	public Color secondaryColour;
	public int changeColourAt;
	[SerializeField]
	public TimerHitZeroEvent hitZeroEvent;

	/*public void setTimer (int minutes,  int seconds) {
		timeLeft = (minutes * 60) + seconds + 0.99f;
	}*/

	private void Start () {
		textBox = this.GetComponent<Text> ();
		prevMin = -1;
		prevSec = -1;
	}

	// Update is called once per frame
	void Update() {
		int curMin = (int)timeLeft / 60;
		int curSec = (int)timeLeft % 60;

		// change colour to red when timer low
		if (curSec < changeColourAt && curMin == 0 && textBox.color != secondaryColour) {
			textBox.color = secondaryColour;
		}

		// update display only if it has changed
		if (curSec != prevSec) {
			textBox.text = curMin + ":" + curSec.ToString ("00");
		}

		// don't go below zero
		if (timeLeft > 0)
		{
			timeLeft -= Time.deltaTime;
		}
		else {
			hitZeroEvent.Invoke();
			enabled = false;
		}

		
    }

	public bool isZero()
	{
		return timeLeft <= 0;
	}
}
