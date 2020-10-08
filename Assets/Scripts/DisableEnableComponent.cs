using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEnableComponent : MonoBehaviour
{
	public MonoBehaviour component;
	public bool disableOnStart = false;

    // Start is called before the first frame update
    void Start()
    {
        if (disableOnStart) {
			component.enabled = false;
		}
    }

	// Update is called once per frame
	private void disableComponent ()
	{
		component.enabled = false;
	}

	private void enableComponent ()
	{
		component.enabled = true;
	}
}
