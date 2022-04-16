using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleEffect : MonoBehaviour
{
    private SpriteRenderer sr;
    // Start is called before the first frame update
    [SerializeField] private float timeSinceLoad;
    [SerializeField] private float alpha;
    private float scale;
    void Start()
    {
        timeSinceLoad = 0;
        Destroy(gameObject, 5);
        sr = gameObject.GetComponent<SpriteRenderer>();
        alpha = 0.3f;
        scale = 0.44f;
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLoad += Time.deltaTime;
        if (alpha > 0){
            alpha -= Time.deltaTime / 2;
            sr.color = new Color(1,1,1,alpha);
            scale += Time.deltaTime / 1.5f;
            gameObject.transform.localScale = new Vector3(scale, scale, scale);
        }
        
    }
}