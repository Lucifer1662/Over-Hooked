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
        SceneManager.LoadScene("Jackson Test 2");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("Jackson Test 2");
    }

    public void LevelThree()
    {
        SceneManager.LoadScene("Jackson Test 2");
    }
}
