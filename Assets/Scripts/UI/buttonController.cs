using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonController : MonoBehaviour {

    public string name;     //inspector string to find the game object
    public bool active;     //inspector boolean to set the for the menu

    public void menuButton()
    {
        //create the menu game object
        GameObject menu;

        //find and set the menu variable to the game object in the scene
        menu = GameObject.Find(name);
        //set the menu game objects active variable
        menu.GetComponent<menuBehaviour>().active = active;
    }

    public void loadLevel(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

    public void pause()
    {
        Time.timeScale = 0.0f;
    }

    public void unpause()
    {
        Time.timeScale = 1.0f;
    }

    public void disableButton(Button button)
    {
        button.interactable = false;
    }

    public void enableButton(Button button)
    {
        button.interactable = true;
    }
}
