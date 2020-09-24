using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ColourGroup {
    public string name;
    public List<MeshRenderer> materials;
}

public class ColourName {
    public string name;
    public Color colour;
}

public class Colourer : MonoBehaviour
{

    [SerializeField]
    public List<ColourGroup> colourGroups;
    // Start is called before the first frame update
    public void Colour(List<ColourName> colourNames) {
        foreach (ColourName c1 in colourNames) {
            foreach (ColourGroup g1 in colourGroups) {
                if (g1.name == c1.name) {
                    foreach (MeshRenderer meshRenderer in g1.materials) {
                        meshRenderer.material.color = c1.colour;
                    }
                }
            }
        }

    }
}
