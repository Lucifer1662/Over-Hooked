using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class GoBack : UnityEvent { }

public class PlayerSelectionController : MonoBehaviour
{
    public List<PlayerSelectedController> playerSelectedControllers;
    public GoBack goBack;


    // Update is called once per frame
    void Update()
    {
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
}
