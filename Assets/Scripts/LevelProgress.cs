using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelProgress : MonoBehaviour
{
    private static readonly string LevelProgressName = "LevelProgress";
    public void SetLevelProgress(int level) {
        PlayerPrefs.SetInt(LevelProgressName, level);
    }

    public static int GetLevelProgress() {
        return PlayerPrefs.GetInt(LevelProgressName);
    }
}
