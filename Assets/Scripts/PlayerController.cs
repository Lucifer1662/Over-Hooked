
using System.Collections.Generic;
using UnityEngine;
using System;

using UnityEngine.Events;

[System.Serializable]
public class CatchedFishEvent : UnityEvent { }
public class PlayerController : MonoBehaviour
{
    public int playerNumber;
    PlayerMovement playerMovement;
    public PlayerRodControl playerRodControl;
    public PlayerScore playerScore;
    public CharacterParameters characteristics;
    public StickTo cameraStick;

    [SerializeField]
    public CatchedFishEvent catchedFish;

    private Action catchFish = null;

    private Vector3 direction;
    private bool lookAtFish = false;

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
                    catchedFish.Invoke();

                };
            };

    }

    bool movenent = true;

    // Update is called once per frame
    void Update()
    {

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
		if (movenent) {
			playerMovement.Move (direction);
		}



        var plane = new UnityEngine.Plane(Vector3.up, transform.position);

        var dis = 0.0f;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out dis))
        {

            var worldPosition = ray.GetPoint(dis);
            direction.x = worldPosition.x - transform.position.x;
            direction.z = worldPosition.z - transform.position.z;

           
        }

        //direction.x = Input.GetAxis("HorizontalLook");

        playerMovement.Look(direction);

       
        if (playerRodControl.hookInstance)
        {
            if (cameraStick.parent == transform)
            {
                lookAtFish = true;
                cameraStick.extraOffset = playerRodControl.hookInstance.transform.position - transform.position;
            }
        }
        else if (lookAtFish)
        {
            //re zero the camera but do not constantly override the extra offset
            cameraStick.extraOffset = Vector3.zero;
            lookAtFish = false;
        }
            

    
        if (Input.GetButtonDown("Cast"))
        {

            bool didCast = playerRodControl.StartedCasting();

            if (catchFish != null)
            {
                catchFish();
                catchFish = null;
            }
        }


        if (Input.GetButtonUp("Cast"))
        {
            bool finishedCast = playerRodControl.EndedCasting();
		}

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
