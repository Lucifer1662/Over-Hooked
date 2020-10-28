using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackToStart : MonoBehaviour
{
    public GameObject cantSwimText;
    private Vector3 position;
    private Quaternion rotation;
    private int deadCount = 0;
    private string text = "placeHolder";
    private void Start()
    {
        // set initial player position and rotation
        position = transform.position;
        rotation = transform.rotation;
    }
    public void MoveBack() {
        deadCount++;

        // teleport
        transform.position = position;
        transform.rotation = rotation;

        // show texts
        if(cantSwimText.name == "DontSwimText"){
            if(deadCount == 1){
                text = "I FORGOT I CAN'T SWIM.";
                createPopUp();
            }else if (deadCount == 2){
                text = "I'D BETTER STAY \n ON THE ISLAND.";
                createPopUp();
            }else if (deadCount == 3){
                text = "COME ON, THIS IS NOT FUN!";
                createPopUp();
            }else if (deadCount == 4){
                text = "FOUR TIMES! \nIT'S BEEN FOUR TIMES!";
                createPopUp();
            }else if (deadCount == 5){
                text = "FINAL WARNING! \nSTOP GOING INTO THE SEA!";
                createPopUp();
            }else{
                gameOver();
            }
            
        }else if (cantSwimText.name == "Level2DontSwim"){
            if(deadCount == 1){
                text = "I DON'T\nWANNA TOUCH THAT\nFREEZING WATER AGAIN.";
                createPopUp();
            }else if (deadCount == 2){
                text = "I'M ASSUMING\nTHAT WAS THE LAST TIME.";
                createPopUp();
            }else if (deadCount == 3){
                text = "HOW DARE YOU\n I'M IN THE SAME SUIT\nAS THE LAST GAME!";
                createPopUp();
            }else if (deadCount == 4){
                text = "... I ... AM\nALMOST...OUTOF\n...STRENGTH...";
                createPopUp();
                // slow down the moving speed as penalty
                GameObject player = GameObject.FindWithTag("Player");
                var playerSpeed = player.GetComponent<PlayerMovement>().speed;
                player.GetComponent<PlayerMovement>().speed = playerSpeed * 0.3f;
            }else{
                gameOver();
            }
        }
    }

    void createPopUp(){
        var before = Instantiate(cantSwimText, transform.position, Quaternion.Euler(90, 0, 0));
        var after = before.GetComponent<TextMesh>();
        after.text = text;
    }

    void gameOver(){
        GameObject time = GameObject.FindWithTag("Timer");
        Timer t = time.GetComponent<Timer>();
        t.timeLeft = 0;
    }

}