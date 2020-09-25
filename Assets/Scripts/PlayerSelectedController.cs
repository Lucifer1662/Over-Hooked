using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectedController : MonoBehaviour
{
    [System.NonSerialized]
    public CharacterParameters playerCharactersitc = null;
    public bool isReady;

    public GameObject playerSelected;
    public GameObject notSelected;
    public GameObject ready;
    private void Start()
    {

    }

    public void Update()
    {
        if (playerCharactersitc == null){
            notSelected.SetActive(true);
            ready.SetActive(false);
            playerSelected.SetActive(false);
        }
        else{
            if (isReady) {
                notSelected.SetActive(false);
                ready.SetActive(true);
                playerSelected.SetActive(false);
            }
            else
            {
                notSelected.SetActive(false);
                ready.SetActive(false);
                playerSelected.SetActive(true);
            }
                
        }
    }

}
