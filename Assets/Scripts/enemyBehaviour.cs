using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour {

    public bool canMove;
    public bool startMove;

    public int speed;

    private Vector3 startPos;
    public Vector3 endPos;

    private float step;

	// Use this for initialization
	void Start () {
        //initialize the start position
		startPos = this.transform.position;
        //add the start positions values to the end position (this allows for proper movement)
        endPos += startPos;
        //setting the movement
        startMove = true;
        //speed of the enemy
        speed = 2;
        
	}
	
	// Update is called once per frame
	void Update () {
        //if the enemy can move
        if (canMove == true)
        {
            //update the speed value (multiplied by deltatime for smooth movement)
            step = speed * Time.deltaTime;
            //if the movement is just starting
            if (startMove == true)
            {
                //move towards the end point
                transform.position = Vector3.MoveTowards(transform.position, endPos, step);
                //if the current position reaches the endpoint
                if (transform.position == endPos)
                    //start moving back
                    startMove = false;
            }
            //if start move == false
            else
            {
                //move towards the start point
                transform.position = Vector3.MoveTowards(transform.position, startPos, step);
                //if the current position reaches the startpoint
                if (transform.position == startPos)
                    //restart the movement pattern
                    startMove = true;
            }
        }
	}
}
