using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Text stageName;
    void Start()
    {
        gameObject.GetComponent<Image>().CrossFadeAlpha(0,2,false);
        stageName.CrossFadeAlpha(0,2,false);
    }
}
