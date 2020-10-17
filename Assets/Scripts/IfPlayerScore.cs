using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class ThreshHoldEvent : UnityEvent { }
public class IfPlayerScore : MonoBehaviour
{

    public PlayerScore score;
    public int threshhold;
    public Text scoreDisplay;
    [SerializeField]
    public ThreshHoldEvent isAbove;
    [SerializeField]
    public ThreshHoldEvent isBelow;
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay.text = score.score.ToString () + "/" + threshhold;
    }


    // Update is called once per frame
    public void TestPlayerScoreThreshhold()
    {
        if (score.score >= threshhold)
        {
            isAbove.Invoke();
            Debug.Log("Score Above");
        }
        else {
            isBelow.Invoke();
        }
    }
}
