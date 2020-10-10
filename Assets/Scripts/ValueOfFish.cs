using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueOfFish : MonoBehaviour
{
	public int smallFishValue = 1;
	public int mediumFishValue = 2;
	public int largeFishValue = 3;

	public int pointToAdd = 0;

	public int GetValue(string str)
	{
		if (str.Equals("FishSmall(Clone)")) {
			return smallFishValue;
		} else if (str.Equals ("FishMedium(Clone)")) {
			return mediumFishValue;
		} else if (str.Equals ("FishLarge(Clone)")) {
			return largeFishValue;
		} else {
			Debug.Log ("Unknown fish type - assigned 1 point");
			return 1;
		}
	}

}
