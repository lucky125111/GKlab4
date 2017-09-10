using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour {

    private Rigidbody _rb { get; set; }
    private bool Finished { get; set; }
    public Vector3 InitialPosition { get; set; }
    public Quaternion InitialRoatetion { get; set; }
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Finished = false;
        InitialPosition = transform.position;
        InitialRoatetion = transform.rotation;
        Debug.Log(InitialPosition);
        Debug.Log(InitialRoatetion);

    }

    //onclick
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            Time.timeScale = 1;
            transform.SetPositionAndRotation(transform.position + Vector3.right, InitialRoatetion);
        }

        if (Input.GetKeyUp(KeyCode.D))
            transform.SetPositionAndRotation(transform.position + Vector3.left, InitialRoatetion);

        if (Input.GetKeyUp(KeyCode.Space) && !Finished)
        {
            Debug.Log("ball thrown");
            _rb.velocity = Vector3.forward * 10;
        }

        if (Input.GetKeyUp(KeyCode.R) && Finished)
        {
            Debug.Log("resetting");
            transform.position = InitialPosition;
            Finished = false;
        }

        if (transform.position.y < 0.0f)
        {
            Finished = true;
            _rb.velocity = Vector3.zero;
            _rb.rotation = InitialRoatetion;
            Debug.Log("fnished");
        }

        Debug.Log(_rb.velocity);
        Debug.Log(transform.position);

    }
}
