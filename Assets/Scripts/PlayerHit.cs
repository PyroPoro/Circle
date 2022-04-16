using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject outerHitbox;
    void Start()
    {
        outerHitbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       // if(Input.GetKey(KeyCode.Space)){
        //    outerHitbox.SetActive(true);
       // }
        if(Input.GetKey("X")){
            outerHitbox.SetActive(true);
        }
        if(Input.GetKey("Z")){
            outerHitbox.SetActive(true);
        }
        outerHitbox.SetActive(false);
    }
}
