using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
	public float duration = 2f;
	private bool isActive = false;
	private Text image;

	// Start is called before the first frame update
	void Start ()
	{
		image = GetComponent<Text> ();
		image.CrossFadeAlpha (1, 0, false);
	}

	// Update is called once per frame
	void Update ()
	{
		if (isActive) {
		image.CrossFadeAlpha (0, duration, false);
		}
	}

	public void Fade() {
		isActive = true;
	}
}
