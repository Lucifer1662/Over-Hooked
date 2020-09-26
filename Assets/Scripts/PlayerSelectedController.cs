using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectedController : MonoBehaviour
{

    public CharacterParameters playerCharactersitc = new CharacterParameters();
    public bool isSelected = false;
    public bool isReady = false;
    public List<Color> playerColors;
    public int currentColourIndex;
    public PlayerController player;

    public GameObject playerSelected;
    public GameObject notSelected;
    public GameObject ready;
    bool wasZero = true;
    
    private void Start()
    {
        playerCharactersitc.color = playerColors[currentColourIndex];
        player.SetPlayerCharacteristics(playerCharactersitc);

    }

    public void Update()
    {
        if (!isSelected){
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
            //selected
            else
            {
                notSelected.SetActive(false);
                ready.SetActive(false);
                playerSelected.SetActive(true);
                var horizontal = Input.GetAxis("Horizontal" + playerCharactersitc.number);
                if (wasZero)
                {
                    if (horizontal > 0.5f)
                    {
                        currentColourIndex++;
                        if (currentColourIndex == playerColors.Count)
                        {
                            currentColourIndex = 0;
                        }
                        wasZero = false;

                        playerCharactersitc.color = playerColors[currentColourIndex];
                        player.SetPlayerCharacteristics(playerCharactersitc);
                    }
                    if (horizontal < -0.5f)
                    {
                        currentColourIndex--;
                        if (currentColourIndex == -1) {
                            currentColourIndex = playerColors.Count - 1;
                        }
                        wasZero = false;

                        playerCharactersitc.color = playerColors[currentColourIndex];
                        player.SetPlayerCharacteristics(playerCharactersitc);
                    }
     

                    
                }
                else {
                    if (horizontal >= -0.5f && horizontal <= 0.5f) {
                        wasZero = true;
                    }
                }


            }
                
        }
    }

}
