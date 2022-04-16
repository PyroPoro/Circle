using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    private float xPos;
    private float yPos;
    private float rotation;
    public float bpm = 0;
    public float moveSpeed;
    private GameObject target;
    public ParticleSystem burst;
    void Start()
    {
        burst.Stop();
        xPos = transform.position.x;
        yPos = transform.position.y;
        rotation = (Mathf.Atan2(yPos,xPos) * Mathf.Rad2Deg) - 90;
        transform.Rotate(0f,0f,rotation);
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }
}
