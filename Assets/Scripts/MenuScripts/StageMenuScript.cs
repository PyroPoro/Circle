using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageMenuScript : MonoBehaviour
{
    public void reloadCurrentScene(){
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void quitGame(){
        SceneManager.LoadScene("Menu");
    }
}
