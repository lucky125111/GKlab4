using System.Collections.Generic;
using Assets;
using UnityEngine;

public class Pins : MonoBehaviour
{
    public List<Vector3> InitialPinsPosition { get; set; }

    // Use this for initialization
    private void Start()
    {
        InitialPinsPosition = new List<Vector3>();
        for (var i = 0; i < transform.childCount; i++)
            InitialPinsPosition.Add(transform.GetChild(i).localPosition);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (GameStatus.IsFinished)
        {
            var collapsedCount = 0;
            for (var i = 0; i < transform.childCount; i++)
            {
                if (InitialPinsPosition[i] != transform.GetChild(i).localPosition)
                    collapsedCount++;


                ResetPositions(i);
                foreach (var rb in GetComponentsInChildren<Rigidbody>())
                {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
            }
            GameStatus.IsFinished = false;
        }
    }

    private void ResetPositions(int i)
    {
        transform.GetChild(i).localPosition = InitialPinsPosition[i];
        transform.GetChild(i).localRotation = Quaternion.identity;
    }
}