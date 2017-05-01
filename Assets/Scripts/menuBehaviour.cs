using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuBehaviour : MonoBehaviour {

    //menu positions and active variables
    public Vector3 menuStart;
    public Vector3 menuEnd;
    public bool active = false;

    //the button components
    public Button playButton;
    public Button settingsButton;
    public Button creditsButton;

    //the menus rectangle transform
    private RectTransform rectTran;

    //this function is used as soon as the game starts, before the start function
    private void Awake()
    {
        //get the attached objects rectangle Transform
        rectTran = GetComponent<RectTransform>();
        //set the start position 
        menuStart = rectTran.position;
    }

    // Use this for initialization
    void Start () {
        //add of the end position to allow for proper movement
        rectTran.position += menuEnd;
	}
	
	// Update is called once per frame
	void Update () {
        //if the menu is active
		if (active == true)
        {
            //Slide the menu over using linear interpolation
            rectTran.position = Vector3.Lerp(rectTran.position, menuStart, 0.1f);

            if (playButton && settingsButton && creditsButton)
            {
                //Set Buttons interactable to false to avoid accidentaly hitting them
                playButton.interactable = false;
                settingsButton.interactable = false;
                creditsButton.interactable = false;
            }
        }
        else
        {
            //Slide the menu back
            rectTran.position = Vector3.Lerp(rectTran.position, menuEnd, 0.1f);

            if (playButton && settingsButton && creditsButton)
            {
                //Set Buttons interactable back to true
                playButton.interactable = true;
                settingsButton.interactable = true;
                creditsButton.interactable = true;
            }
        }
	}
}
