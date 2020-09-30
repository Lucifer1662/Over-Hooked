using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


[System.Serializable]
public class GoBack : UnityEvent { }

public class PlayerSelectionController : MonoBehaviour
{
    public List<PlayerSelectedController> playerSelectedControllers;
    public GoBack goBack;

    [SerializeField]
    public InputAction join;

    [SerializeField]
    public InputAction back;

    private void OnEnable()
    {
        join.Enable();
        back.Enable();
    }

    private void OnDisable()
    {
        join.Disable();
        back.Disable();
    }

    private void Awake()
    {
        join.performed += (context) =>
        {
            for (int j = 0; j < playerSelectedControllers.Count; j++)
            {
                if (!playerSelectedControllers[j].isSelected)
                {
                    playerSelectedControllers[j].isSelected = true;
                    playerSelectedControllers[j].playerCharactersitc.number = context.control.device.deviceId;
                    playerSelectedControllers[j].isReady = false;

                    return;
                }
                else if (playerSelectedControllers[j].playerCharactersitc.number == context.control.device.deviceId)
                {
                    playerSelectedControllers[j].isReady = true;
                    return;
                }
            }
        };

        back.performed += (context) =>
        {
            for (int j = 0; j < playerSelectedControllers.Count; j++)
            {
                if (playerSelectedControllers[j].isSelected &&
                    playerSelectedControllers[j].playerCharactersitc.number == context.control.device.deviceId)
                {
                    if (playerSelectedControllers[j].isReady == true)
                    {
                        playerSelectedControllers[j].isReady = false;
                    }
                    else
                    {
                        playerSelectedControllers[j].isSelected = false;
                    }
                    return;
                }
            }
            //if we get to here then the player that click back button is not in game and we shall return to the main menu
            goBack.Invoke();

        };
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfAllReady();

   
    }


    void CheckIfAllReady()
    {


        if (playerSelectedControllers.Any((p) => p.isReady)
            && playerSelectedControllers.All((p) => !p.isSelected || p.isReady))
        {

            PlayerSpawner.characterParameters = new List<CharacterParameters>();
            playerSelectedControllers.ForEach((p) =>
            {

                if (p.isReady)
                {
                    PlayerSpawner.characterParameters.Add(p.playerCharactersitc);
                }
            });

            SceneManager.LoadScene("Luke Test Scene", LoadSceneMode.Single);
        }

    }
}
