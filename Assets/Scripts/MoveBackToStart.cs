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
    private GameObject player;
    private void Start()
    {
        // set initial player position and rotation
        position = transform.position;
        rotation = transform.rotation;
        player = GameObject.FindWithTag("Player");
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
            //text for lv2
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
                
                var playerSpeed = player.GetComponent<PlayerMovement>().speed;
                player.GetComponent<PlayerMovement>().speed = playerSpeed * 0.3f;
            }else{
                gameOver();
            }

            //text for lv3
        }else if (cantSwimText.name == "Level3DontSwim"){
            if(deadCount == 1){
                text = "WELL, AT LEAST THE WATER\nIS MUCH WARMER THAN THE LAST LEVEL.";
                createPopUp();
            }else if (deadCount == 2){
                text = "YOU KNOW WHAT,\nI JUST TAUGHT MYSELF HOW TO SWIM!\nJUST KIDDING:)";
                createPopUp();
            }else if (deadCount == 3){
                text = "USE THE HOOK TO CATCH FISH, NOT ME!!";
                createPopUp();
            }else if (deadCount == 4){
                text = "AH！NEXT VACATION\nI WILL DEFINITELY GO TO THE DESERT";
                createPopUp();
            }else if (deadCount == 5){
                text = "SERIOUSLY?\nDROWNED ME FIVE TIMES IN ONE MINUTE?";
                createPopUp();
            }else if (deadCount == 6){
                text = "DO NOT FORCE ME TO DO THAT!";
                createPopUp();
            }else if (deadCount == 7){
                text = "ONE...LAST...CHANCE";
                createPopUp();
            
            }else{
                // pass the game when the player died so many times as an easter egg.
                text = "OKAY...YOU WIN\nI CAN'T STAND IT ANY MORE!\nJUST GO AND LEAVE ME ALONE!\nBUT DON'T TELL THOSE\n[CARELESS DEVELOPERS]\nI LEFT A BACKDOOR!";
                createPopUp();
                player.GetComponent<PlayerController>().enabled = false;
                player.GetComponent<PlayerMovement>().enabled = false;
                StartCoroutine(delayEnd());
            }
        }else if(cantSwimText.name == "TutorialText"){
            text = "PLEASE STAY ON THE ISLAND\nI CANNOT SWIM";
            createPopUp();
        }
    }

    void createPopUp(){
        var preText = GameObject.FindWithTag("DontSwim");
        if (preText == null){
            popUp();
        }else{
            Destroy(preText);
            popUp();
        } 
    }

    void popUp(){
        cantSwimText.GetComponent<TextMesh>().text = text;
        Instantiate(cantSwimText, transform.position, Quaternion.Euler(90, 0, 0));
    }

    void gameOver(){
        GameObject time = GameObject.FindWithTag("Timer");
        Timer t = time.GetComponent<Timer>();
        t.timeLeft = 0;
    }

    IEnumerator delayEnd() {
        yield return new WaitForSeconds(8);
        player.GetComponent<PlayerScore>().score = 6;
        var HighScorePopup = GameObject.Find("/Canvas/Highscore Popup");
        HighScorePopup.SetActive(false);
        gameOver();
    }

}