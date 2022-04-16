using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuController : MonoBehaviour
{
    private bool isHitting = false;
    public Animator PlayerAnimator;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.Z) | Input.GetKeyDown(KeyCode.X)){
            isHitting = true;
            PlayerAnimator.SetTrigger("Hit");
            PlayerAnimator.SetBool("isIdle", false);
        }
        if(PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_Pulse") && Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.Z) | Input.GetKeyDown(KeyCode.X)){
            isHitting = true;
            PlayerAnimator.SetTrigger("Rehit");
        }
    }
    public void setIdle(){
        PlayerAnimator.SetBool("isIdle", true);
    }
    public void setIsHitting(){
        isHitting = false;
    }
    public bool getIsHitting(){
        return isHitting;
    }
}
