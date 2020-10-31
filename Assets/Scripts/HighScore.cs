﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{
    public Text currentScoreDisplay;
    private int currentScore;
	public Text highScoreDisplay;

    private static readonly string TutorialHignScoreName = "TutorialHighScore";
    private static readonly string LevelOneHignScoreName = "LevelOneHighScore";
    private static readonly string LevelTwoHignScoreName = "LevelTwoHighScore";
    private static readonly string LevelThreeHignScoreName = "LevelThreeHighScore";

    private void Start ()
	{
        string[] strArr= currentScoreDisplay.text.Split('/');
        currentScore = int.Parse(strArr[0]);
        checkHighScore();
	}

    private void checkHighScore(){
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Tutorial"){
            if (currentScore > GetLevelHighScore("Tutorial")){
                SetLevelHighScore("Tutorial", currentScore);
            }
            highScoreDisplay.text = GetLevelHighScore("Tutorial").ToString();
        }
        else if (scene.name == "Level 1"){
            if (currentScore > GetLevelHighScore("Level 1")){
                SetLevelHighScore("Level 1", currentScore);
            }
            highScoreDisplay.text = GetLevelHighScore("Level 1").ToString();
        }
        else if (scene.name == "Level 2"){
            if (currentScore > GetLevelHighScore("Level 2")){
                SetLevelHighScore("Level 2", currentScore);
            }
            highScoreDisplay.text = GetLevelHighScore("Level 2").ToString();
        }
        else if (scene.name == "Level 3"){
            if (currentScore > GetLevelHighScore("Level 3")){
                SetLevelHighScore("Level 3", currentScore);
            }
            highScoreDisplay.text = GetLevelHighScore("Level 3").ToString();
        }
        
    }


    public void SetLevelHighScore(string levelName, int highScore) {
        if (levelName == "Tutorial"){
           PlayerPrefs.SetInt(TutorialHignScoreName, highScore);
        }
        else if (levelName == "Level 1"){
           PlayerPrefs.SetInt(LevelOneHignScoreName, highScore);
        }
        else if (levelName == "Level 2"){
           PlayerPrefs.SetInt(LevelTwoHignScoreName, highScore);
        }
        else if (levelName == "Level 3"){
           PlayerPrefs.SetInt(LevelThreeHignScoreName, highScore);
        }
        
    }

    public static int GetLevelHighScore(string levelName) {
        if (levelName == "Tutorial"){
           return PlayerPrefs.GetInt(TutorialHignScoreName);
        }
        else if (levelName == "Level 1"){
           return PlayerPrefs.GetInt(LevelOneHignScoreName);
        }
        else if (levelName == "Level 2"){
           return PlayerPrefs.GetInt(LevelTwoHignScoreName);
        }
        else{
           return PlayerPrefs.GetInt(LevelThreeHignScoreName);
        }
    }

}
