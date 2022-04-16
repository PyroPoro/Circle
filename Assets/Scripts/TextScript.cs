using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScript : MonoBehaviour
{
    // Start is called before the first frame update
    Color32 startColor;
    Color32 endColor;
    float t = 0;
    float startTime;
    void Start()
    {
        startTime = Time.time;
        startColor = gameObject.transform.GetChild(0).GetComponent<TextMeshPro>().color;
        endColor = new Color32(255,255,255,0);
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.GetChild(0).GetComponent<TextMeshPro>().color = Color32.Lerp(startColor, endColor, t);
        t += Time.deltaTime;
        gameObject.transform.Translate(0,0.02f,0);
    }
}
