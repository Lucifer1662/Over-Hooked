using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionController : MonoBehaviour
{
    public List<PlayerSelectedController> playerSelectedControllers;


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

                for (int j = 0; j < playerSelectedControllers.Count; j++)
                {
                    if (playerSelectedControllers[j].playerCharactersitc == null)
                    {
                        playerSelectedControllers[j].playerCharactersitc = new CharacterParameters()
                        {
                            number = i
                        };

                        return;
                    }
                }

            }

        }
    }
}
