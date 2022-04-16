using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    private bool showCursor;
    private bool isGodMode;
    float volume;
    public Toggle cursorToggle;
    public Toggle godmodeToggle;
    public Slider volumeSlider;
    public GameObject MenuManager;
    public Canvas MainMenu;
    public GameObject Settings;
    private float timeSinceEnabled;
    void Start()
    {
        if(!PlayerPrefs.HasKey("Cursor_Visible")){
            PlayerPrefs.SetInt("Cursor_Visible", 0);
        }
        showCursor = PlayerPrefs.GetInt("Cursor_Visible") == 1;
        isGodMode = PlayerPrefs.GetInt("isGodMode") == 1;
        godmodeToggle.GetComponent<Toggle>().SetIsOnWithoutNotify(isGodMode);
        cursorToggle.GetComponent<Toggle>().SetIsOnWithoutNotify(showCursor);
        volumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Music_Volume");
    }

    void OnEnable(){
        timeSinceEnabled = Time.time;
        transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color32(50,50,50,1);
        gameObject.transform.GetChild(0).GetComponent<Image>().CrossFadeAlpha(255f,0.5f,false);
    }

    void Update()
    {
        if(Time.time - timeSinceEnabled > 0.5f){
            transform.GetChild(1).gameObject.SetActive(true);
        }
        cursorToggle.GetComponent<Toggle>().isOn = showCursor;    
        PlayerPrefs.SetInt("Cursor_Visible", showCursor ? 1 : 0);
        PlayerPrefs.SetInt("isGodMode", isGodMode ? 1 : 0);
        Cursor.visible = (PlayerPrefs.GetInt("Cursor_Visible") == 1);
        if(Input.GetKey(KeyCode.Mouse1) && !(PlayerPrefs.GetInt("Cursor_Visible") == 1)){
            Cursor.visible = true;
        }
        volume = volumeSlider.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("Music_Volume", volume);
    }
    public void SetShowCursor(){
        showCursor = !showCursor;
    }
    public void SetIsGodMode(){
        isGodMode = !isGodMode;
    }
    public void backButton(){
        Settings.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(0).GetComponent<Image>().CrossFadeAlpha(0,1,false);
        MenuManager.GetComponent<MenuManager>().changeActiveMenu(0);
    }
}
