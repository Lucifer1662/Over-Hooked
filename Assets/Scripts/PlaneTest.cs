using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTest : MonoBehaviour
{

    public int divisions;
    public float width;
    // Start is called before the first frame update
    void Start()
    {
        Plane plane = new Plane(divisions, width);
        this.GetComponent<MeshFilter>().mesh = plane.Generate();
    }

    private void Update()
    {

       
    }


    public int getAt(float x, float y, int vertsInARow)
    {

        x *= vertsInARow / (divisions+1);
        y *= vertsInARow / (divisions + 1);

        int index = (int)(y * vertsInARow + x);


        if (index >= vertsInARow * vertsInARow) {
            int j = 0;
        }
        return index;
    }
    public void PassTerrainData(Vector3[] verts, int vertsInARow, float maxHeight = 20)
    {

        Plane plane = new Plane(divisions, width);
        this.GetComponent<MeshFilter>().mesh = plane.Generate();

        this.GetComponent<MeshCollider>().sharedMesh = this.GetComponent<MeshFilter>().mesh;
        Material mat = this.GetComponent<MeshRenderer>().material;


        mat.SetFloat("_CellLength", width / divisions);


        //Vector2[] heights = new Vector2[(divisions + 1) * (divisions + 1)];
        //int i = 0;
        //for (int y = 0; y <= divisions; y++)
        //    for (int x = 0; x <= divisions; x++)
        //    { 
            
        //    {

        //        int dis = 3;
        //        float left = x - dis >= 0 ? verts[getAt(x - dis, y, vertsInARow)].y : verts[getAt(x, y, vertsInARow)].y;
        //        float right = x + dis < divisions ? verts[getAt(x + dis, y, vertsInARow)].y : verts[getAt(x, y, vertsInARow)].y;
        //        float up = (y + dis) < divisions ? verts[getAt(x, y + dis, vertsInARow)].y : verts[getAt(x, y, vertsInARow)].y;
        //        float down = y - dis >= 0 ? verts[getAt(x, y - dis, vertsInARow)].y : verts[getAt(x, y, vertsInARow)].y;

        //        heights[i].x = -(right - left)*1.0f;
        //        heights[i].y = -(up - down)*1.0f;
        //        i++;
        //    }
        //}
           
        

        //this.GetComponent<MeshFilter>().mesh.uv = heights;
    }

}
