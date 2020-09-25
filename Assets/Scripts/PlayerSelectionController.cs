using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


[System.Serializable]
public class GoBack : UnityEvent { }

public class PlayerSelectionController : MonoBehaviour
{
    public List<PlayerSelectedController> playerSelectedControllers;
    public GoBack goBack;


    // Update is called once per frame
    void Update()
    {
        CheckIfAllReady();


        for (int i = 0; i < 4; i++)
        {

            if (Input.GetButtonDown("CastRod" + i))
            {
               
                for (int j = 0; j < playerSelectedControllers.Count; j++)
                {
                    if (playerSelectedControllers[j].playerCharactersitc != null)
                    {
                        if (playerSelectedControllers[j].playerCharactersitc.number == i)
                        {
                            playerSelectedControllers[j].playerCharactersitc = null;
                            return;
                        }
                    }
                }

             

            }

            if (Input.GetButtonDown("Join"+i)) {
         
          
                for (int j = 0; j < playerSelectedControllers.Count; j++)
                {
                    if (playerSelectedControllers[j].playerCharactersitc == null)
                    {
                        playerSelectedControllers[j].playerCharactersitc = new CharacterParameters()
                        {
                            number = i
                        };
                        playerSelectedControllers[j].isReady = false;

                        return;
                    }
                    else if (playerSelectedControllers[j].playerCharactersitc.number == i) {
                        playerSelectedControllers[j].isReady = true;
                        return;
                    }
                }
            }

            if (Input.GetButtonDown("Back" + i))
            {

                for (int j = 0; j < playerSelectedControllers.Count; j++)
                {
                    if (playerSelectedControllers[j].playerCharactersitc != null && 
                        playerSelectedControllers[j].playerCharactersitc.number == i)
                    {
                        if (playerSelectedControllers[j].isReady == true)
                        {
                            playerSelectedControllers[j].isReady = false;
                        }
                        else {
                            playerSelectedControllers[j].playerCharactersitc = null;
                        }
                        return;
                    }
                }
                //if we get to here then the player that click back button is not in game and we shall return to the main menu
                goBack.Invoke();
            }

        }
    }


    void CheckIfAllReady()
    {

        if(playerSelectedControllers.Any((p)=>p.playerCharactersitc != null) && 
        playerSelectedControllers.All((p) =>  p.playerCharactersitc == null || p.isReady)) {
            Debug.Log("Load");
            PlayerSpawner.characterParameters = new List<CharacterParameters>();
            playerSelectedControllers.ForEach((p) =>
            {
                if (p.playerCharactersitc != null)
                    PlayerSpawner.characterParameters.Add(p.playerCharactersitc);
            });

            SceneManager.LoadScene("Luke Test Scene", LoadSceneMode.Single);
        }

    }
}
