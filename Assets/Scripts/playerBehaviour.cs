using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehaviour : MonoBehaviour {

    //player variables
    public int health;
    public int speed;
    public int iForget;
    public int score;

    public bool canHit;

    //important positions
    private Vector2 currPos;
    public Vector2 mousePos;

    

	// Use this for initialization
	void Start () {
        //initializing the player variables
        health = 1;
        speed = 3;
        score = 0;
        canHit = true;
	}
	
	// Update is called once per frame
	void Update () {

        //Update the players current position constantly
        currPos = this.GetComponent<Transform>().position;
        
        //if the left mouse button is held down
        if (Input.GetMouseButton(0))
        {
            if (transform.position.x <= Screen.width)
            //get the mouses position
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //update the speed by deltatime for smooth movement
            float step = speed * Time.deltaTime;
            //move towards the mouse position
            transform.position = Vector2.MoveTowards(currPos, mousePos, step);
        }

        //if health is less than equal to 0
        if (health <= 0)
        {
            //kill yourself
            killMe();
        }
	}

    //this is a built in function is used for detecting collisions when they start
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the player collides with another game oject with the tag Collectable
        if (collision.gameObject.tag == "Collectable")
        {
            //increment the score by 1
            score++;
            //destroy the colliding object
            Destroy(collision.gameObject);
        }        
    }

    //this is a built in function used for detecting collisions while the are still happening
    private void OnCollisionStay2D(Collision2D collision)
    {
        //if the player collides with another game object with the tag Enemy
        if (collision.gameObject.tag == "Enemy" && canHit == true)
        {
            //decrease health
            health--;
            //set canHit to false so the player wont get constantly hurt
            canHit = false;
            //start the health timer coroutine 
            StartCoroutine("healthTimer");
        }
    }

    //function to be called when you want to 
    public void killMe()
    {
        //destroys this game object
        Destroy(this.gameObject);
    }

    //coroutine to set can hit back to true
    IEnumerator healthTimer()
    {
        //waits for 1 seconds before returning canHit to true
        yield return new WaitForSeconds(1);

        //sure you should get this one
        canHit = true;
    }

}
