using UnityEngine;

public class FollowBallCamera : MonoBehaviour {

    public GameObject BowlingBall;      
    private Vector3 Offset { get; set; }         

    void Start()
    {
       BowlingBall = GameObject.FindWithTag("Player");
       Offset = transform.position - BowlingBall.transform.position;
    }

    void LateUpdate()
    {
        transform.position = BowlingBall.transform.position + Offset;
    }
}
