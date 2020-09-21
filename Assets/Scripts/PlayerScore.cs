using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score;


    public void AddPoint() {
        score++;
    }

    public int GetScore() {
        return score;
    }
}
