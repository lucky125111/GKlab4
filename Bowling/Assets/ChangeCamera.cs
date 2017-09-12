using UnityEngine;

namespace Assets
{
    class ChangeCamera : MonoBehaviour
    {
        public Camera SideCamera { get; set; }
        public Camera BackCamera { get; set; }
        public Camera FollowingCamera { get; set; }
        public Camera TopCamera { get; set; }
        public Camera MovingCamera { get; set; }

        void Start()
        {
            SideCamera = GameObject.Find("SideCamera").GetComponent<Camera>();
            BackCamera = GameObject.Find("BackCamera").GetComponent<Camera>();
            FollowingCamera = GameObject.Find("FollowingCamera").GetComponent<Camera>();
            TopCamera = GameObject.Find("TopCamera").GetComponent<Camera>();
            MovingCamera = GameObject.Find("MovingCamera").GetComponent<Camera>();

            SideCamera.enabled = true;
            BackCamera.enabled = false;
            FollowingCamera.enabled = false;
            TopCamera.enabled = false;
            MovingCamera.enabled = false;
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                SideCamera.enabled = true;
                BackCamera.enabled = false;
                FollowingCamera.enabled = false;
                TopCamera.enabled = false;
                MovingCamera.enabled = false;
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                SideCamera.enabled = false;
                BackCamera.enabled = true;
                FollowingCamera.enabled = false;
                TopCamera.enabled = false;
                MovingCamera.enabled = false;
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                SideCamera.enabled = false;
                BackCamera.enabled = false;
                FollowingCamera.enabled = true;
                TopCamera.enabled = false;
                MovingCamera.enabled = false;
            }
            if (Input.GetKey(KeyCode.Alpha4))
            {
                SideCamera.enabled = false;
                BackCamera.enabled = false;
                FollowingCamera.enabled = false;
                TopCamera.enabled = true;
                MovingCamera.enabled = false;
            }
            if (Input.GetKey(KeyCode.Alpha5))
            {
                SideCamera.enabled = false;
                BackCamera.enabled = false;
                FollowingCamera.enabled = false;
                TopCamera.enabled = false;
                MovingCamera.enabled = true;
            }

        }
    }
}
