using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHeightMap : MonoBehaviour
{
    public float width;
    public int resolution;
    public float waterLevel;
    public Texture2D texture;
    public float max;
    public float min;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
        GetComponent<MeshRenderer>().material.SetTexture("_MainTex", texture);
    }

    public void Generate()
    {
        var pos = transform.position;
        var offset = 100;
        pos.y += waterLevel + offset;
   
  
        var heights = new float[resolution, resolution];
        texture = new Texture2D(resolution, resolution);

        for (int x = 0; x < resolution; x++)
        {
            for (int y = 0; y < resolution; y++)
            {
                RaycastHit hit;
                float reshalf = resolution / 2.0f;
                var posOffset = new Vector3(
                    (x - reshalf) / reshalf * (width/2),
                    0,
                    (y - reshalf) / reshalf * (width/2));

                int layerMask = 1 << 10;

                if (Physics.Raycast(pos + posOffset, -Vector3.up, out hit, 100000, layerMask))
                {
                    heights[x, y] = offset - hit.distance;
                }
                else {
                    heights[x, y] = min;
                }
            }
        }


  
        for (int x = 0; x < resolution; x++)
        {
            for (int y = 0; y < resolution; y++)
            {
                var d = (heights[x, y] - min) / (max-min);
            
                texture.SetPixel(resolution-x, resolution-y, new Color(d, d, d, 1));
            }
        }
        texture.Apply();

    }
}
