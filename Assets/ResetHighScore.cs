using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHighScore : MonoBehaviour
{
    public void ResetScores()
    {
        PlayerPrefs.SetInt("LevelOneHighScore", 0);
        PlayerPrefs.SetInt("LevelTwoHighScore", 0);
        PlayerPrefs.SetInt("LevelThreeHighScore", 0);
    }

    
}
