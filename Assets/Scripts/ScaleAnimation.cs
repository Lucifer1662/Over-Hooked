using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAnimation : MonoBehaviour
{
	public float startScale = 0;
	public float endScale = 1;
	public bool growOnStart;
	private bool isGrowing = false;
	private bool isShrinking = false;
	public float speed = 2;
	private float n;

	void Start ()
	{
		if (growOnStart) {
			Grow ();
		}
	}

	// Update is called once per frame
	void Update()
    {
		if (isGrowing) {
			if (n >= endScale) {
				isGrowing = false;
			}

			n += Time.deltaTime * speed;
			n = Mathf.Clamp (n, startScale, endScale);
			transform.localScale = new Vector3 (n, n, n);
		}

		else if (isShrinking) {
			if (n <= startScale) {
				isShrinking = false;
			}

			n += Time.deltaTime * speed;
			n = Mathf.Clamp (n, startScale, endScale);
			transform.localScale = new Vector3 (n, n, n);
		}

	}

	public void Grow()
	{
		transform.localScale = new Vector3 (startScale, startScale, startScale);
		n = startScale;
		isGrowing = true;
	}

	public void Shrink()
	{
		transform.localScale = new Vector3 (endScale, endScale, endScale);
		n = endScale;
		isShrinking = true;
	}
}
