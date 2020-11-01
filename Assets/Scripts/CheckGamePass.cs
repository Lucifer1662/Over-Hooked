using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckGamePass : MonoBehaviour
{
    private float delay = 15;
    public GameObject credit;
    public GameObject title;
    public GameObject menu;

    public GameObject startButton;
    public GameObject InstructionButton;
    public GameObject quitButton;
    private List<GameObject> buttons;

    public GameObject skipButton;
    public int testSwitch;
    
    // Start is called before the first frame update
    void Start()
    {
        // Test switch code for testing purpose only
        // Put in 0 to turn credit off
        // Put in 1 to turn it on
        // Otherwise won't affect the regular process
        if (testSwitch == 0){
            this.GetComponent<SaveGamePass>().SetGamePass(0);
        }
        else if (testSwitch == 1){
            this.GetComponent<SaveGamePass>().SetGamePass(1);
        }

        buttons = new List<GameObject>{startButton, InstructionButton, quitButton};

        // Check if the player has passed all levels
        if (this.GetComponent<SaveGamePass>().GetGamePass() == 1){
            credit.SetActive(true);
            skipButton.SetActive(true);
            SetMenuTransparent();
            menu.SetActive(false);
        }else{
            credit.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<SaveGamePass>().GetGamePass() == 1){
            delay -= Time.deltaTime;
            // Title fading out
            if (delay <= 8 && delay > 0) {
                TitleFadeOut(2);
            }
            // Skip button fading in
            if (delay <= 6.5 && delay > 0) {
                ButtonFadeIn(skipButton, 5);
            }
            // Main menu comes back after the credit
            if (delay <= 0) {
                credit.SetActive(false);
                menu.SetActive(true);
                TitleFadeIn(2);
                MenuFadeIn(2);
                ButtonFadeOut(skipButton, 5);

                if (title.GetComponent<Image>().color.a >= 1) {
                    // Skip the credit scene when main menu is called from elsewhere
                    this.GetComponent<SaveGamePass>().SetGamePass(2);
                    skipButton.SetActive(false);
                    this.gameObject.SetActive(false);
                }
            }
        }
 
    }

    // Skip the credit
    public void Skip(){
        credit.GetComponent<AdaptAspectRatio>().transitionTime = 1;
        delay = 0;
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
            SetButtonTransparent(item);
        }
    }

    // Set single button transparent
    private void SetButtonTransparent(GameObject button){

        Image buttonImage = button.GetComponent<Image>();
        Text buttonText = button.transform.GetChild (0).gameObject.GetComponent<Text>();

        buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, 0);
        buttonText.color = new Color(buttonText.color.r, buttonText.color.g, buttonText.color.b, 0);
        
    }

    // Fade in transition for main menu button
    // Applys for both image and text under each button
    private void MenuFadeIn(float speed){

        foreach (GameObject item in buttons)
        {
            ButtonFadeIn(item, speed);
        }
    }

    // Fade in transition for a single button
    private void ButtonFadeIn(GameObject button, float speed){
        Image buttonImage = button.GetComponent<Image>();
        Text buttonText = button.transform.GetChild (0).gameObject.GetComponent<Text>();

        if (buttonImage.color.a < 1){
            buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, buttonImage.color.a + (speed * Time.deltaTime));
            buttonText.color = new Color(buttonText.color.r, buttonText.color.g, buttonText.color.b, buttonText.color.a + (speed * Time.deltaTime));
        }
    }

    // Fade out transition for a single button
    private void ButtonFadeOut(GameObject button, float speed){
        Image buttonImage = button.GetComponent<Image>();
        Text buttonText = button.transform.GetChild (0).gameObject.GetComponent<Text>();

        if (buttonImage.color.a > 0){
            buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, buttonImage.color.a - (speed * Time.deltaTime));
            buttonText.color = new Color(buttonText.color.r, buttonText.color.g, buttonText.color.b, buttonText.color.a - (speed * Time.deltaTime));
        }
    }

    
}
