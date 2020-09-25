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
    [SerializeField]
    public static List<CharacterParameters> characterParameters = new List<CharacterParameters>();
    public GameObject player;
    
    void Start()
    {
        for (int i = 0; i < transform.childCount && i < characterParameters.Count; i++)
        {
            var pos = transform.GetChild(i).transform.position;
            characterParameters[i].spawnPosition = pos;
            SpawnPlayer(characterParameters[i]);
        } 
            
    }

    void SpawnPlayer(CharacterParameters playerChar) {

        var instance = Instantiate(player, playerChar.spawnPosition, Quaternion.identity);
        instance.GetComponent<PlayerController>().SetPlayerCharacteristics(playerChar);

    }

}
