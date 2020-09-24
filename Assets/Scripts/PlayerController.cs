using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerNumber;
    PlayerMovement playerMovement;
    public PlayerRodControl playerRodControl;
    public PlayerScore playerScore;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerScore = GetComponent<PlayerScore>();

        playerRodControl.GetComponent<PlayerRodControl>().fishBitingEvent 
            += (sender, catchFishFunc) => {
            if (Input.GetButtonDown("CastRod" + playerNumber))
            {
                catchFishFunc();
                playerScore.AddPoint();
            }
        };

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = new Vector3(
            Input.GetAxis("Horizontal" + playerNumber),
            0,
            Input.GetAxis("Vertical" + playerNumber));
        playerMovement.Move(direction);


        if(Input.GetButtonDown("CastRod" + playerNumber))
            playerRodControl.StartedCasting();
        
        if(Input.GetButtonUp("CastRod" + playerNumber))
            playerRodControl.EndedCasting();
    }

    public void SetPlayerCharacteristics(CharacterParameters characteristics) {
        playerNumber = characteristics.number;
        
    }
}
