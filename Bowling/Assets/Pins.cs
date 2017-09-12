using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Assets;
using UnityEngine;

public class Pins : MonoBehaviour {

    public List<Vector3> PinsPosition { get; set; }

	// Use this for initialization
	void Start () {
        PinsPosition = new List<Vector3>();
        for(int i= 0; i < transform.childCount; i++)
        {
            PinsPosition.Add(transform.GetChild(i).localPosition);
        }

    }
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (GameStatus.IsFinished)
	    {
	        int collapsedCount = 0;
	        for (int i = 0; i < transform.childCount; i++)
	        {
	            if (PinsPosition[i] != transform.GetChild(i).localPosition)
	                collapsedCount++;


                ResetPositions(i);
                foreach (var rb in GetComponentsInChildren<Rigidbody>())
                {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }

            }
            Debug.Log(collapsedCount);
	        GameStatus.IsFinished = false;
	    }
    }

    private void ResetPositions(int i)
    {

        transform.GetChild(i).localPosition = PinsPosition[i];
        transform.GetChild(i).localRotation = Quaternion.identity;
    }
}
