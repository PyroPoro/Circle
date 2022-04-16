using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int ActiveMenu = 0;
    public Canvas MainMenu;
    public Canvas LevelSelectionMenu;
    public Canvas SettingsMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ActiveMenu == 0){
            MainMenu.gameObject.SetActive(true);
            LevelSelectionMenu.gameObject.SetActive(false);
            SettingsMenu.gameObject.SetActive(false);
        }else if(ActiveMenu == 1){
            MainMenu.gameObject.SetActive(false);
            LevelSelectionMenu.gameObject.SetActive(true);
            SettingsMenu.gameObject.SetActive(false);
        }else if(ActiveMenu == 2){
            MainMenu.gameObject.SetActive(false);
            LevelSelectionMenu.gameObject.SetActive(false);
            SettingsMenu.gameObject.SetActive(true);
        }
    }

    IEnumerator changeActiveMenuCor(int active){
        yield return new WaitForSeconds(1);
        ActiveMenu = active;
    }

    public void changeActiveMenu(int newActive){
        StartCoroutine(changeActiveMenuCor(newActive));
    }
}
