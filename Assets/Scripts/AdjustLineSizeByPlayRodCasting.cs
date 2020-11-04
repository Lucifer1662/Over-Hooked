using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustLineSizeByPlayRodCasting : MonoBehaviour
{
    public PlayerRodControl rod;
    public LineRenderer line;
    public float maxMultipler;

    float startWidthInitial;
    float endWidthInitial;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        startWidthInitial = line.startWidth;
        endWidthInitial = line.endWidth;
        

    }

    // Update is called once per frame
    void Update()
    {
        float percent = rod.percentageCasting();
        line.SetPosition(1, Vector3.forward * 7 * (1 + percent * (maxMultipler - 1)));
        line.startWidth = startWidthInitial * (1 + percent * (maxMultipler - 1));
        line.endWidth = endWidthInitial * (1 + percent * (maxMultipler-1));

    }
}
