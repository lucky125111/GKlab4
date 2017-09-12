using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLight : MonoBehaviour {

    public Light BallLight { get; set; }
    public Light PinsLight { get; set; }
    public Light PointStraightUp { get; set; }
    public Light PointRotated { get; set; }

	// Use this for initialization
	void Start () {
	    BallLight = GameObject.Find("BallLight").GetComponent<Light>();
	    PinsLight = GameObject.Find("PinsLight").GetComponent<Light>();
	    PointStraightUp = GameObject.Find("PointStraightUp").GetComponent<Light>();
	    PointRotated = GameObject.Find("PointRotated").GetComponent<Light>();

	    BallLight.enabled = true;
	    PinsLight.enabled = true;
	    PointStraightUp.enabled = false;
	    PointRotated.enabled = false;

	}

    // Update is called once per frame
    void FixedUpdate () {
        if (Input.GetKey(KeyCode.Q))
        {
            BallLight.enabled = !BallLight.enabled;
        }
        if (Input.GetKey(KeyCode.W))
        {
            PinsLight.enabled = !PinsLight.enabled;
        }
        if (Input.GetKey(KeyCode.E))
        {
            PointStraightUp.enabled = !PointStraightUp.enabled;
        }
        if (Input.GetKey(KeyCode.R))
        {
            PointRotated.enabled = !PointRotated.enabled;
        }
    }
}
