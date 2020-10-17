using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundWhenMoving : MonoBehaviour
{
	public AudioSource sound;

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButton ("Vertical") || Input.GetButton ("Horizontal")) {
			if (!sound.isPlaying) {
				sound.Play ();
			}
		} else if (sound.isPlaying){
			sound.Pause ();
		}

	}
}
