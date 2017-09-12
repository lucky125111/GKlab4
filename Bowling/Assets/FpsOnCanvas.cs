using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsOnCanvas : MonoBehaviour {
	// Update is called once per frame
	void Update () {
	    var txt = GameObject.Find("FPSCounter").GetComponent<Text>();
	    txt.text = "FPS: " + (int)(1f / Time.unscaledDeltaTime);
	}
}
