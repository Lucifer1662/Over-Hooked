using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TutorialFishedEvent : UnityEvent { }
public class Tutorial : MonoBehaviour
{

    public int state = 0;
    [SerializeField]
    public TutorialFishedEvent finished;
    bool calledFinished = false;


    // Update is called once per frame
    void Update()
    {

        var states = new List<GameObject>();
        int i = 0;
        for ( i = 0; i < transform.childCount; i++)
        {
            states.Add(transform.GetChild(i).gameObject);
        }

        i = 0;
        foreach (GameObject state in states)
        {
            if(state && this.state != i && (this.state < states.Count || state != states[this.state]))
                state.SetActive(false);
            i++;
        }

        if (state < states.Count)
        {
            if (states[state] && !states[state].activeSelf)
            {
                states[state].SetActive(true);
            }
        }
        else if (!calledFinished)
        {
            finished.Invoke();
            calledFinished = true;
        }


    }

    public void Next()
    {
        state++;
    }
}
