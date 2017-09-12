using UnityEngine;

namespace Assets
{
    class ChangeCamera : MonoBehaviour
    {
        public Camera SideCamera;
        public Camera BackCamera;
        public Camera FollowingCamera;
        public Camera TopCamera;
        public Camera MovingCamera;

        void Start()
        {
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
