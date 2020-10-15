using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void LevelZero()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void LevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("Luke Ice");
    }

    public void LevelThree()
    {
        SceneManager.LoadScene("Night Level");
    }
}
