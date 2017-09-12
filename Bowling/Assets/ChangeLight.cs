using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLight : MonoBehaviour
{

    public Light BallLight;
    public Light PinsLight;
    public Light PointStraightUp;
    public Light PointRotated;


    // Use this for initialization
    void Start () {
	    BallLight.enabled = true;
	    PinsLight.enabled = true;
	    PointStraightUp.enabled = false;
	    PointRotated.enabled = false;

        //przekazac swiatlo
        //Shader.SetGlobalVector("_lightPos", );
    }

    // Update is called once per frame
    void Update () {
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
