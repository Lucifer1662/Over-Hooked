using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CharacterParameters {
    public Color color;
    public int number;
    public Vector3 spawnPosition;
}

public class PlayerSpawner : MonoBehaviour
{
    public static int playerCount = 4;
    [SerializeField]
    public List<CharacterParameters> characterParameters = new List<CharacterParameters>();
    public GameObject player;
    
    void Start()
    {
        for (int i = 0; i < transform.childCount && i < playerCount; i++)
        {
            var pos = transform.GetChild(i).transform.position;
            characterParameters[i].number = i;
            characterParameters[i].spawnPosition = pos;
            SpawnPlayer(characterParameters[i]);
        } 
            
    }

    void SpawnPlayer(CharacterParameters playerChar) {

        var instance = Instantiate(player, playerChar.spawnPosition, Quaternion.identity);
        instance.GetComponent<PlayerController>().SetPlayerCharacteristics(playerChar);

    }

}
