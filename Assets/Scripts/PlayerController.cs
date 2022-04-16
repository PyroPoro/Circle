using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator PlayerAnimator;
    public GameObject outerHitbox;
    public GameObject menu;
    private bool showMenu = false;
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = (PlayerPrefs.GetInt("Cursor_Visible") == 1);
        if(Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.Z) | Input.GetKeyDown(KeyCode.X)){
            PlayerAnimator.SetTrigger("Hit");
            PlayerAnimator.SetBool("isIdle", false);
        }
        if(PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_Pulse") && Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.Z) | Input.GetKeyDown(KeyCode.X)){
            PlayerAnimator.SetTrigger("Rehit");
        }
        if(Input.GetKey(KeyCode.Mouse1) && !(PlayerPrefs.GetInt("Cursor_Visible") == 1)){
            Cursor.visible = true;
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            showMenu = !showMenu;
        }
        menu.SetActive(showMenu);
    }
    public void setIdle(){
        PlayerAnimator.SetBool("isIdle", true);
    }
}
