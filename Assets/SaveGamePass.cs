using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGamePass : MonoBehaviour
{
    private static readonly string GamePassName = "GamePass";
    public void SetGamePass(int identifier) {
        PlayerPrefs.SetInt(GamePassName, identifier);
    }

    public int GetGamePass() {
        return PlayerPrefs.GetInt(GamePassName);
    }
}
