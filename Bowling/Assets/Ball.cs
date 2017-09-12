using Assets;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody Rigidbody { get; set; }
    private Vector3 initialPosition { get; set; }
    public bool preFinish { get; set; }
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        GameStatus.IsFinished = false;
        GameStatus.IsSetup = true;
        preFinish = false;
        initialPosition = transform.localPosition;
        preFinish=false;
    }

    void FixedUpdate()
    {
        if (GameStatus.IsSetup)
        {
            ChangeInitialBallPosition();
            ThrowBall();
        }
        if (transform.localPosition.y < 0.9)        //nie wiem czy to jest najlepsza opcja, mozna tez sprawdzic czy sie nie rusza
        {
            preFinish = true;
        }

        if (preFinish)
        {
            if (Input.GetKey(KeyCode.R))
            {
                GameStatus.IsFinished = true;
                Debug.Log("game finished");
                ResetPosition();
                preFinish = false;
                GameStatus.IsSetup = true;
            }
        }
    }

    private void ThrowBall()
    {
        if (Input.GetKey(KeyCode.Space) && !preFinish && !GameStatus.IsFinished)
        {
            GameStatus.IsSetup = false;
            Rigidbody.AddForce(Vector3.forward * 5000);
        }
    }

    private void ChangeInitialBallPosition()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.localPosition.x + Vector3.left.x > -5)
                transform.Translate(Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.localPosition.x + Vector3.right.x < 5)
                transform.Translate(Vector3.right);
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
