using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackCurrentScore : MonoBehaviour
{
    public Text currentScoreDisplay;
	public Text resumeScoreDisplay;

    public void DisplayCurrentScore()
    {
        resumeScoreDisplay.text = currentScoreDisplay.text;
    }
}
