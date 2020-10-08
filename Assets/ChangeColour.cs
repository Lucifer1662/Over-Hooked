﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    private Color[] colors = {new Color(0.9803922f, 0.5019608f, 0.4509804f), 
        new Color (1f, 0.627451f, 0.482353f),
		new Color (0.9843138f, 0.6980392f, 0.5490196f),
		new Color (0.872f, 0.174242f, 0.160448f)};
    private int randomColour;
    private int rndColor;
    // Start is called before the first frame update
    void Start()
    {
        int lengthOfColors = colors.Length;  
        rndColor = Random.Range(0, lengthOfColors);
		
		transform.GetChild(6).GetComponent<MeshRenderer> ().materials [0].color = colors [rndColor];
		transform.GetChild (6).GetComponent<MeshRenderer> ().materials [1].color = new Color (colors [rndColor].r, colors [rndColor].g + 0.2f, colors [rndColor].b + 0.2f);
        
    }

}
