using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackToStart : MonoBehaviour
{
    public GameObject cantSwimText;
    private Vector3 position;
    private Quaternion rotation;
    private int deadCount = 0;
    private string text = "I FORGOT I CAN'T SWIM.";
    private void Start()
    {
        position = transform.position;
        rotation = transform.rotation;
    }
    public void MoveBack() {
        deadCount++;
        transform.position = position;
        transform.rotation = rotation;
        if(cantSwimText){
            if(deadCount == 1){
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
                GameObject time = GameObject.FindWithTag("Timer");
                Timer t = time.GetComponent<Timer>();
                t.timeLeft = 0;
            }
            
        }
    }

    void createPopUp(){
        var before = Instantiate(cantSwimText, transform.position, Quaternion.Euler(90, 0, 0));
        var after = before.GetComponent<TextMesh>();
        after.text = text;
    }

}