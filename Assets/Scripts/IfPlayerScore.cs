using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ThreshHoldEvent : UnityEvent { }
public class IfPlayerScore : MonoBehaviour
{

    public PlayerScore score;
    public int threshhold;
    [SerializeField]
    public ThreshHoldEvent isAbove;
    [SerializeField]
    public ThreshHoldEvent isBelow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void TestPlayerScoreThreshhold()
    {
        if (score.score >= threshhold)
        {
            isAbove.Invoke();
        }
        else {
            isBelow.Invoke();
        }
    }
}
