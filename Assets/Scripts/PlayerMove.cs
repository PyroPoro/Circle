using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D circleCollider2D;
    [SerializeField] private int direction = 0;
    [SerializeField] private LayerMask floorLayerMask;
    public float moveSpeed;
    public float speedLimit;
    void Start()
    {

    }

    private void Awake(){
        circleCollider2D = transform.GetComponent<CircleCollider2D>();
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D)){
            direction = 1;
        }
        else if (Input.GetKey(KeyCode.A)){
            direction = 2;
        }
        else{
            direction = 0;
        }
        if (IsGrounded() && Input.GetKeyDown(KeyCode.W)){
            rb.velocity += new Vector2(0,7);
        }
    }

    void FixedUpdate(){
        if (direction == 0){
            if (rb.velocity.x > 0){
                rb.AddForce(new Vector2(-3f,0));
            }
            if (rb.velocity.x < 0){
                rb.AddForce(new Vector2(3f,0));
            }
        }
        if (direction == 1){
            if (rb.velocity.x < speedLimit){
                rb.AddForce(new Vector2(3,0));
            }
        }
        if (direction == 2){
            if (rb.velocity.x > -speedLimit){
                rb.AddForce(new Vector2(-3,0));
            }
        }
        // if (Input.GetKey(KeyCode.D)){
        //     rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        // } else {
        //     if (Input.GetKey(KeyCode.A)){
        //         rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        //     } else {
        //         rb.velocity = new Vector2(0, rb.velocity.y);
        //     }
        // }

        if (rb.velocity.x > speedLimit){
            rb.velocity = new Vector2(speedLimit, rb.velocity.y);
        }
        if (rb.velocity.x < -speedLimit){
            rb.velocity = new Vector2(-speedLimit, rb.velocity.y);
        }
    }

    private bool IsGrounded(){
        float extraHeight = 0.02f;   
        if (Physics2D.OverlapCircleAll(circleCollider2D.bounds.center, (circleCollider2D.radius * transform.localScale.x) + extraHeight, floorLayerMask).Length > 0) {
            return true;
        }else{
            return false;
        }
    }
}
