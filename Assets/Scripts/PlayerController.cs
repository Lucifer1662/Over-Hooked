using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerController : MonoBehaviour
{
    public int playerNumber;
    PlayerMovement playerMovement;
    public PlayerRodControl playerRodControl;
    public PlayerScore playerScore;
    public CharacterParameters characteristics;
    [SerializeField]
    public InputAction cast;
    [SerializeField]
    public InputAction movmentInput;
    [SerializeField]
    public InputAction stopInput;

    private Action catchFish = null;

    private Vector3 direction;

    private void Awake()
    {

        cast.started += (context) =>
        {
            if (context.control.device.deviceId == playerNumber)
            {

                bool didCast = playerRodControl.StartedCasting();

                if (catchFish != null)
                {
                    catchFish();
                    catchFish = null;
                }
            }

        };



        cast.canceled += (context) =>
        {
            if (context.control.device.deviceId == playerNumber)
            {
                bool finishedCast = playerRodControl.EndedCasting();

            }

        };


        stopInput.started += (context) =>
        {
            if (context.control.device.deviceId == playerNumber)
            {
                movenent = !movenent;
            }
        };

        movmentInput.performed += (context) =>
        {
            if (context.control.device.deviceId == playerNumber)
            {
                
                var dir = context.ReadValue<Vector2>();

                direction = new Vector3(dir.x, 0, dir.y);

                
            }

        };





    }

    private void OnEnable()
    {
        cast.Enable();
        movmentInput.Enable();
        stopInput.Enable();
    }

    private void OnDisable()
    {
        cast.Disable();
        movmentInput.Disable();
        stopInput.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {

        playerMovement = GetComponent<PlayerMovement>();
        playerScore = GetComponent<PlayerScore>();
        ApplyColour();




        playerRodControl.GetComponent<PlayerRodControl>().fishBitingEvent
            += (sender, catchFishFunc) =>
            {
                catchFish = () =>
                {
                    catchFishFunc();
                    playerScore.AddPoint();

                };
            };

    }

    bool movenent = true;

    // Update is called once per frame
    void Update()
    {
        if (movenent)
            playerMovement.Move(direction);

        playerMovement.Look(direction);

    }

    public void SetPlayerCharacteristics(CharacterParameters characteristics)
    {
        playerNumber = characteristics.number;
        this.characteristics = characteristics;
        ApplyColour();


    }

    void ApplyColour()
    {
        var colourer = GetComponent<Colourer>();
        var colours = new List<ColourName>();
        colours.Add(new ColourName() { colour = characteristics.color, name = "Main" });
        colourer.Colour(colours);
    }
}
