using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane
{

    public int divisions;
    public float width;

    public Plane(int divisions, float width) {
        this.divisions = divisions;
        this.width = width;
    }

    private int At(int x, int y) {
        return x + y * (divisions+1);
    }

    public Mesh Generate() {
        Mesh mesh = new Mesh();
        List<Vector3> vertices = new List<Vector3>();
        List<Vector2> uvs = new List<Vector2>();
 
        for (int y = 0; y <= divisions; y++)
        {
            for (int x = 0; x <= divisions; x++)
            {
                vertices.Add(new Vector3(x/(float)divisions * width - width/2, 0, y/(float)divisions * width-width/2));
                uvs.Add(new Vector2(1-x / (float)divisions, 1-y / (float)divisions));
            }
        }
        //
        //8 9 10 11
        //4 5 6 7
        //0 1 2 3
        List<int> indices = new List<int>();
        for (int y = 0; y < divisions; y++)
        {
            for (int x = 0; x < divisions; x++)
            {
                indices.Add(At(x,y));
                indices.Add(At(x, y+1));
                indices.Add(At(x + 1, y));

                indices.Add(At(x + 1, y));
                indices.Add(At(x, y+1));
                indices.Add(At(x+1, y+1));
            }
        }
        mesh.vertices  = vertices.ToArray();
        mesh.triangles = indices.ToArray();
        mesh.uv = uvs.ToArray();
        mesh.RecalculateNormals();
        return mesh;
    }

}
