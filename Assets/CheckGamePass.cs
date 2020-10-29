using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckGamePass : MonoBehaviour
{
    private float delay = 18;
    public GameObject credit;
    public GameObject title;
    public GameObject menu;

    public GameObject startButton;
    public GameObject InstructionButton;
    public GameObject quitButton;
    private List<GameObject> buttons;
    
    // Start is called before the first frame update
    void Start()
    {
        buttons = new List<GameObject>{startButton, InstructionButton, quitButton};

        // Check if the player has passed all levels
        if (this.GetComponent<SaveGamePass>().GetGamePass() == 1){
            credit.SetActive(true);
            SetMenuTransparent();
            menu.SetActive(false);
        }else{
            credit.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        // Title fading out
        if (delay <= 10 && delay > 0) {
            TitleFadeOut(2);
		}
        // Main menu comes back after the credit
		if (delay <= 0) {
            credit.SetActive(false);
            menu.SetActive(true);
            TitleFadeIn(2);
            MenuFadeIn(2);

            if (title.GetComponent<Image>().color.a == 255) {
                this.gameObject.SetActive(false);
		    }
		}
        
        
    }




    // Fade out transition for the titile
    private void TitleFadeOut(float speed){
        Image titleImage = title.GetComponent<Image>();
        if (titleImage.color.a > 0){
            titleImage.color = new Color(titleImage.color.r, titleImage.color.g, titleImage.color.b, titleImage.color.a - (speed * Time.deltaTime));
        }
    }

    // Fade in transition for the titile
    private void TitleFadeIn(float speed){
        Image titleImage = title.GetComponent<Image>();
        titleImage.color = new Color(titleImage.color.r, titleImage.color.g, titleImage.color.b, titleImage.color.a + (speed * Time.deltaTime));
    }

    // Set main menu transparent
    // For the fade in transition later
    private void SetMenuTransparent(){

        foreach (GameObject item in buttons)
        {
            Image buttonImage = item.GetComponent<Image>();
            Text buttonText = item.transform.GetChild (0).gameObject.GetComponent<Text>();

            buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, 0);
            buttonText.color = new Color(buttonText.color.r, buttonText.color.g, buttonText.color.b, 0);
        }
    }

    // Fade in transition for each button
    // Applys for both image and text under each button
    private void MenuFadeIn(float speed){

        foreach (GameObject item in buttons)
        {
            Image buttonImage = item.GetComponent<Image>();
            Text buttonText = item.transform.GetChild (0).gameObject.GetComponent<Text>();

            buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, buttonImage.color.a + (speed * Time.deltaTime));
            buttonText.color = new Color(buttonText.color.r, buttonText.color.g, buttonText.color.b, buttonText.color.a + (speed * Time.deltaTime));
        }
    }
}
