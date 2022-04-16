using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if (player.transform.position.y < 3.5f &&player.transform.position.y > -3.5f){
            transform.position = new Vector3(player.transform.position.x, 0, -10);
        }
    }
}
