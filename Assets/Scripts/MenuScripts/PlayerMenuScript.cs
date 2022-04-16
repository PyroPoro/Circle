using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMenuScript : MonoBehaviour
{
    public GameObject player;
    public int selection = 0;
    public Image menu0;
    public Image menu1;
    public Image menu2;
    public Image menu3;
    public Canvas MainMenu;
    public Canvas SettingsMenu;
    public Canvas LevelSelectionMenu;
    public GameObject MenuManager;
    
    void Start()
    {
        SettingsMenu.gameObject.SetActive(false);
    }
    // Update is called once per frame 
    void OnEnable(){
        menuLerpIn();
    }
    void Update()
    {
        Cursor.visible = (PlayerPrefs.GetInt("Cursor_Visible") == 1);
        if(MenuManager.GetComponent<MenuManager>().ActiveMenu == 0){
            if(Input.GetKey(KeyCode.Mouse1) && !(PlayerPrefs.GetInt("Cursor_Visible") == 1)){
                Cursor.visible = true;
            }
            float playerRot = player.transform.eulerAngles.z;
            if(playerRot <= 360 && playerRot > 270){
                selection = 0;
            }
            if (playerRot <= 270 && playerRot > 180){
                selection = 1;
            }
            if (playerRot <= 180 && playerRot > 90){
                selection = 2;
            }
            if (playerRot <= 90 && playerRot > 0){
                selection = 3;
            }
            if(selection == 0){
                menu0.color = new Color32(255,255,255,255);
            }else{
                menu0.color = new Color32(255,255,255,150);
            }
            if(selection == 1){
                menu1.color = new Color32(255,255,255,255);
            }else{
                menu1.color = new Color32(255,255,255,150);
            }
            if(selection == 2){
                menu2.color = new Color32(255,255,255,255);
            }else{
                menu2.color = new Color32(255,255,255,150);
            }
            if(selection == 3){
                menu3.color = new Color32(255,255,255,255);
            }else{
                menu3.color = new Color32(255,255,255,150);
            }
            applySelection(); 
        }
    }

    void applySelection(){
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Mouse0)){
            switch(selection){
            case 0:
                selection0();
                break;
            case 1:
                selection1();
                break;
            case 2:
                Application.Quit();
                break;
            case 3:
                break;
            }
        }
    }

    public void menuLerpOut(){
        StartCoroutine(menuLerpCor(menu0, new Vector3(5.5f,5.5f,0), 1f, true));
        StartCoroutine(menuLerpCor(menu1, new Vector3(5.5f,-5.5f,0), 1f, true));
        StartCoroutine(menuLerpCor(menu2, new Vector3(-5.5f,-5.5f,0), 1f, true));
        StartCoroutine(menuLerpCor(menu3, new Vector3(-5.5f,5.5f,0), 1f, true));
    }
    
    public void menuLerpIn(){
        StartCoroutine(menuLerpCor(menu0, new Vector3(0,0,0), 1f, false));
        StartCoroutine(menuLerpCor(menu1, new Vector3(0,0,0), 1f, false));
        StartCoroutine(menuLerpCor(menu2, new Vector3(0,0,0), 1f, false));
        StartCoroutine(menuLerpCor(menu3, new Vector3(0,0,0), 1f, false));
    }
    void selection0(){
        menuLerpOut();
        //LevelSelectionMenu.GetComponent<LevelSelectionScript>().menuLerpIn();
        MenuManager.GetComponent<MenuManager>().changeActiveMenu(1);
    }

    void selection1(){
        menuLerpOut();
        MenuManager.GetComponent<MenuManager>().changeActiveMenu(2);
    }
    IEnumerator menuLerpCor(Image image ,Vector3 targetPos, float duration, bool lerpOut){
        float time = 0;
        Vector3 startPos = image.transform.position;
        while(time < duration){
            image.transform.position = Vector3.Lerp(startPos, targetPos, time/duration);
            if(lerpOut == true){
                image.color = Color.Lerp(Color.white, new Color(255,255,255,0), time*2);
            }else{
                image.color = Color.Lerp(new Color(255,255,255,0), Color.white, time*2);
            }
            time += Time.deltaTime;
            yield return null;
        }
        image.transform.position = targetPos;
    }
}
