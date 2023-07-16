using UnityEngine;

namespace Bugbear.CameraControls
{
    public class CameraController : MonoBehaviour
    {
        private Transform target;
        public Vector3 offset;

        private void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                target = player.transform;
            }
        }

        private void LateUpdate()
        {
            if (target != null) transform.position = target.position + offset;
        }
    }
}
