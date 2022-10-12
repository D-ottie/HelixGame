using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnClickEvents : MonoBehaviour
{
    public TextMeshProUGUI soundsText;
    void Start() 
    {
        if(GameManager.mute)
            soundsText.text = "/";
        else
            soundsText.text = "";
    }
    public void QuitGame()
    {
       Application.Quit();
       Debug.Log("Quit Game");
    }

    public void MuteGame()
    {
       if(GameManager.mute)
       {
           GameManager.mute = false;
           soundsText.text = "";
       }
       else
       {
           GameManager.mute = true;
           soundsText.text = "/";
       }
    }
}
