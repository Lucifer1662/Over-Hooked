using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
	private ChangeSceneWithDelay sceneChanger;
	public GameObject fader;

	private void Start ()
	{
		sceneChanger = GetComponent<ChangeSceneWithDelay> ();
	}

	public void MainMenu()
    {
		changeTo ("Main Menu");
        //SceneManager.LoadScene("Main Menu");
    }
    public void LevelZero()
    {
		changeTo ("Tutorial");
		//SceneManager.LoadScene("Tutorial");
	}
    public void LevelOne()
    {
		changeTo ("Level 1");
		//SceneManager.LoadScene("Level 1");
    }

    public void LevelTwo()
    {
		changeTo ("Level 2");
		//SceneManager.LoadScene("Level 2");
    }

    public void LevelThree()
    {
		changeTo ("Level 3");
		//SceneManager.LoadScene("Night Level");
    }

	private void changeTo (string name)
	{
		sceneChanger.scene = name;
		sceneChanger.changeScene ();
		fader.SetActive (true);
	}
}
