using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade : MonoBehaviour
{
    void Start(){
        StartCoroutine(fadeInAndOut(gameObject, false, 5f));
    }

    IEnumerator fadeInAndOut(GameObject objectToFade, bool fadeIn, float duration) {
    float counter = 0f;

    //Set Values depending on if fadeIn or fadeOut
    float a, b;
    if (fadeIn)
    {
        a = 0;
        b = 1;
    }
    else
    {
        a = 1;
        b = 0;
    }

    Color currentColor = Color.clear;

    MeshRenderer tempRenderer = objectToFade.GetComponent<MeshRenderer>();

    if (tempRenderer != null)
    {
        currentColor = tempRenderer.material.color;

        //ENABLE FADE Mode on the material if not done already
        tempRenderer.material.SetFloat("_Mode", 2);
        tempRenderer.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        tempRenderer.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        tempRenderer.material.SetInt("_ZWrite", 0);
        tempRenderer.material.DisableKeyword("_ALPHATEST_ON");
        tempRenderer.material.EnableKeyword("_ALPHABLEND_ON");
        tempRenderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        tempRenderer.material.renderQueue = 3000;
    }
    else
    {
        yield break;
    }

    while (counter < duration)
    {
        counter += Time.deltaTime;
        float alpha = Mathf.Lerp(a, b, counter / duration);
        tempRenderer.material.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
        yield return null;
    }
}

}

