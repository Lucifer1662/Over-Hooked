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
    public CharacterParameters characteristics;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerScore = GetComponent<PlayerScore>();
        ApplyColour();

        playerRodControl.GetComponent<PlayerRodControl>().fishBitingEvent 
            += (sender, catchFishFunc) => {
            if (Input.GetButtonDown("CastRod" + playerNumber))
            {
                catchFishFunc();
                playerScore.AddPoint();
            }
        };

    }

    bool movenent = true;

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = new Vector3(
            Input.GetAxis("Horizontal" + playerNumber),
            0,
            Input.GetAxis("Vertical" + playerNumber));

        if(movenent)
            playerMovement.Move(direction);

        playerMovement.Look(direction);

        if (Input.GetButtonDown("Back" + playerNumber))
            movenent = !movenent;
        {
        }


            if (Input.GetButtonDown("CastRod" + playerNumber))
        {
            bool didCast = playerRodControl.StartedCasting();

        }

        if (Input.GetButtonUp("CastRod" + playerNumber))
        {
            bool finishedCast = playerRodControl.EndedCasting();
        }
    }

    public void SetPlayerCharacteristics(CharacterParameters characteristics) {
        playerNumber = characteristics.number;
        this.characteristics = characteristics;
        ApplyColour();


    }

    void ApplyColour() {
        var colourer = GetComponent<Colourer>();
        var colours = new List<ColourName>();
        colours.Add(new ColourName() { colour = characteristics.color, name = "Main" });
        colourer.Colour(colours);
    }
}
