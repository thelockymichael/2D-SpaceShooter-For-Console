using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fade : MonoBehaviour
{
    private void Start()
    {
        FadeIn();
    }
    public void FadeOut()
    {
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", 1.0f, "to", 0.0f,
            "time", 3f, "easetype", "linear",
            "onupdate", "setAlpha"));
    }
    public void FadeIn()
    {
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", 0f, "to", 1f,
            "time", 3f, "easetype", "linear",
            "onupdate", "setAlpha"));
    }
    public void setAlpha(float newAlpha)
    {
        foreach (Material mObj in GetComponent<Renderer>().materials)
        {
            mObj.color = new Color(
                mObj.color.r, mObj.color.g,
                mObj.color.b, newAlpha);
        }
    }

}