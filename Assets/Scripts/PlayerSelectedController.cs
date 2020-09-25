using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectedController : MonoBehaviour
{
    [System.NonSerialized]
    public CharacterParameters playerCharactersitc = null;

    public GameObject playerSelected;
    public GameObject notSelected;
    private void Start()
    {

    }

    public void Update()
    {
        if (playerCharactersitc == null){
            playerSelected.SetActive(false);
            notSelected.SetActive(true);
        }
        else{
            playerSelected.SetActive(true);
            notSelected.SetActive(false);
            playerSelected.GetComponent<Text>().text = "Join as Controller " + (playerCharactersitc.number+1);
        }
    }

}
