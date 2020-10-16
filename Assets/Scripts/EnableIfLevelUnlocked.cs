using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableIfLevelUnlocked : MonoBehaviour
{
    public GameObject unlocked;
    public GameObject locked;
    public int level;
    // Start is called before the first frame update
    void Update()
    {
        if (LevelProgress.GetLevelProgress() >= level)
        {
            unlocked.SetActive(true);
            locked.SetActive(false);
            GetComponent<Button>().interactable = true;
        }
        else {
            unlocked.SetActive(false);
            locked.SetActive(true);
            GetComponent<Button>().interactable = false;
        }
    }
}
