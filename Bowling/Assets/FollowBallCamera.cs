using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBallCamera : MonoBehaviour {

    public GameObject BowlingBall;       //Public variable to store a reference to the player game object


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
       BowlingBall = GameObject.FindWithTag("Player");
       //Calculate and store the offset value by getting the distance between the player's position and camera's position.
       offset = transform.position - BowlingBall.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        //offset = transform.position - BowlingBall.transform.position;
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = BowlingBall.transform.position + offset;
    }
}
