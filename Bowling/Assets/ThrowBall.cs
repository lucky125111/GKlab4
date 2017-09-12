using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    private Rigidbody Rigidbody { get; set; }
    private Vector3 initialPosition { get; set; }
    public bool preFinish { get; set; }
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        //Rigidbody.detectCollisions = true;
        GameStatus.IsFinished = false;
        initialPosition = transform.localPosition;
        preFinish=false;
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space) && !preFinish && !GameStatus.IsFinished)
            Rigidbody.AddForce(Vector3.forward * 1000);

        if (transform.localPosition.y < 0.9)
        {
            preFinish = true;
        }

        if (Input.GetKey(KeyCode.Space) && preFinish)
        {
            GameStatus.IsFinished = true;
            Debug.Log("game finished");
            //wait for spacja
            ResetPosition();
            preFinish = false;

        }
    }

    private void ResetPosition()
    {
        transform.localPosition = initialPosition;
        transform.rotation = Quaternion.identity;
        Rigidbody.velocity = Vector3.zero;
        Rigidbody.angularVelocity = Vector3.zero;
        gameObject.SetActive(true);
    }
    
}
