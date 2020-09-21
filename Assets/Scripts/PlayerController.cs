using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerNumber;
    PlayerMovement playerMovement;
    public PlayerRodControl playerRodControl;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();


        playerRodControl.GetComponent<PlayerRodControl>().fishBitingEvent 
            += (sender, catchFishFunc) => {
            if (Input.GetButtonDown("CastRod" + playerNumber))
            {
                catchFishFunc();
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
}
