using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelectionScript : MonoBehaviour
{
    public GameObject player;
    private List<string> levels = new List<string>();
    public TextAsset levelFile;
    public Image menu0;
    public Image menu1;
    public Image menu2;
    public Image menu3;
    public Image menu4;
    public int selection = 0;
    private int center = 1;
    public Canvas MainMenu;
    public GameObject MenuManager;
    void Start()
    {
        levels.Add("Back"); 
        string levelListText = levelFile.text;
        string temp = "";
        foreach(char ch in levelListText){
            if(ch == ','){
                levels.Add(temp);
                temp = "";
            }else{
                temp += ch;
            }
        }
        levels.Add("Back");
        displayChoices();
    }
    void OnEnable(){
        menuLerpIn();
    }
    void Update()
    {
        Cursor.visible = (PlayerPrefs.GetInt("Cursor_Visible") == 1);
        if(MenuManager.GetComponent<MenuManager>().ActiveMenu == 1){
            if(Input.GetKey(KeyCode.Mouse1) && !(PlayerPrefs.GetInt("Cursor_Visible") == 1)){
                Cursor.visible = true;
            }
            float playerRot = player.transform.eulerAngles.z % 360;
            if((playerRot <= 60 || playerRot > 300) && playerRot > -60){
                selection = 0;
            }
            if(playerRot <= 120 && playerRot > 60){
                selection = 2;
            }
            if(playerRot <= 180 && playerRot > 120){
                selection = 3;
            }
            if(playerRot <= 240 && playerRot > 180){
                selection = 4;
            }
            if(playerRot <= 300 && playerRot > 240){
                selection = 1;
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
            if(selection == 4){
                menu4.color = new Color32(255,255,255,255);
            }else{
                menu4.color = new Color32(255,255,255,150);
            }
            displayChoices();
            applySelection();
        }
    }

    public void menuLerpIn(){
        StartCoroutine(menuLerpCor(menu0, new Vector3(0,0,0), 1f, false));
        StartCoroutine(menuLerpCor(menu1, new Vector3(0,0,0), 1f, false));
        StartCoroutine(menuLerpCor(menu2, new Vector3(0,0,0), 1f, false));
        StartCoroutine(menuLerpCor(menu3, new Vector3(0,0,0), 1f, false));
        StartCoroutine(menuLerpCor(menu4, new Vector3(0,0,0), 1f, false));
    }
    public void menuLerpOut(){
        StartCoroutine(menuLerpCor(menu0, new Vector3(0,5,0), 1f, true));
        StartCoroutine(menuLerpCor(menu1, new Vector3(9,0,0), 1f, true));
        StartCoroutine(menuLerpCor(menu2, new Vector3(-9,0,0), 1f, true));
        StartCoroutine(menuLerpCor(menu3, new Vector3(-5.5f,-5.5f,0), 1f, true));
        StartCoroutine(menuLerpCor(menu4, new Vector3(5.5f,-5.5f,0), 1f, true));
    }
    IEnumerator menuLerpCor(Image image,Vector3 targetPos, float duration, bool lerpOut){
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
    void displayChoices(){
        menu0.transform.GetChild(0).GetComponent<TextMeshPro>().text = levels[center];
        menu1.transform.GetChild(0).GetComponent<TextMeshPro>().text = levels[center+1];
        menu2.transform.GetChild(0).GetComponent<TextMeshPro>().text = levels[center-1];
    }
    void applySelection(){
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Mouse0)){
            if(selection == 3 && center > 1){
                center -= 1;
            }
            if(selection == 4 && center < levels.Count-2){
                center += 1;
            }
            if(selection == 0){
                SceneManager.LoadScene(menu0.transform.GetChild(0).GetComponent<TextMeshPro>().text);
            }
            if(selection == 1){
                if(menu1.transform.GetChild(0).GetComponent<TextMeshPro>().text == "Back"){
                    menuLerpOut();
                    MenuManager.GetComponent<MenuManager>().changeActiveMenu(0);
                }else{
                    SceneManager.LoadScene(menu1.transform.GetChild(0).GetComponent<TextMeshPro>().text);
                }
            }
            if(selection == 2){
                if(menu2.transform.GetChild(0).GetComponent<TextMeshPro>().text == "Back"){
                    menuLerpOut();
                    MenuManager.GetComponent<MenuManager>().changeActiveMenu(0);
                }else{
                    SceneManager.LoadScene(menu2.transform.GetChild(0).GetComponent<TextMeshPro>().text);
                }
            }
        }
    }
}
