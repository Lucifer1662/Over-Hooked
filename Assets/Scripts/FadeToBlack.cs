using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
	public float duration = 2f;
	//private bool isActive = false;
	private Image image;

    // Start is called before the first frame update
    void Start()
    {
		image = GetComponent<Image> ();
		image.CrossFadeAlpha (0, 0, false);
	}

    // Update is called once per frame
    void Update()
    {
		//if (isActive) {
			image.CrossFadeAlpha (1, duration, false);
		//}
    }

	//public void Fade() {
	//	isActive = true;
	//}
}
