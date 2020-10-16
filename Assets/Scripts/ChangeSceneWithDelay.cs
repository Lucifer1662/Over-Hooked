using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithDelay : MonoBehaviour
{
	public string scene;
	public float delay;
	private bool isActive = false;
	

	// Update is called once per frame
	void Update()
    {
        if (isActive) {
			delay -= Time.deltaTime;
		}
		if (delay <= 0) {
			SceneManager.LoadScene (scene, LoadSceneMode.Single);
		}
    }

	public void changeScene ()
	{
		isActive = true;
	}
}
