using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWaterAlpha : MonoBehaviour
{
	private MeshRenderer rnderer;
	public Light directionalLight;
	public float lightScale = 0.1f;
	public float waterScale = 0.1f;
	public float rateOfChange = 1f;
	private float initialIntensity;
	private float initialAlpha;
	private float initialDarkAlpha;
	[Space]
	public float maxAlpha = 0.9f;
	public float minAlpha = 0.6f;


	// Start is called before the first frame update
	void Start()
    {
		rnderer = transform.GetComponent<MeshRenderer> ();

		// initialise water alpha
		initialAlpha = rnderer.material.GetColor ("_Colour").a;
		initialDarkAlpha = rnderer.material.GetColor ("_DarkColour").a;

		// initialise light intensity
		initialIntensity = directionalLight.intensity;
	}

    // Update is called once per frame
    void Update()
    {
		float delta = Mathf.PerlinNoise (Time.time * rateOfChange, 0) - 0.5f;
		directionalLight.intensity = initialIntensity + (delta * lightScale);
		changeWaterOpacity ((-delta) * waterScale);
    }

	public void changeWaterOpacity(float amount)
	{
		// set light colour
		Color lightColour = rnderer.material.GetColor ("_Colour");
		lightColour.a = initialAlpha + amount;

		lightColour.a = Mathf.Clamp (lightColour.a, minAlpha, maxAlpha);
		rnderer.material.SetColor ("_Colour", lightColour);

		// set dark colour
		Color darkColour = rnderer.material.GetColor ("_DarkColour");
		darkColour.a = initialDarkAlpha + amount;

		lightColour.a = Mathf.Clamp (lightColour.a, minAlpha, maxAlpha);
		rnderer.material.SetColor ("_DarkColour", darkColour);
	}
}
