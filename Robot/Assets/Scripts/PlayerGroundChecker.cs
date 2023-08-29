using UnityEngine;

namespace RobotDemo
{
    public class PlayerGroundChecker : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private Rigidbody rb;

        [Header("Values")]
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private float playerHeight;
        [SerializeField] private float groundDrag;
        [SerializeField] private float raycastExtension;
        
        private bool grounded;
        private Vector3 hitNormal;
        public bool Grounded => grounded;
        public Vector3 HitNormal => hitNormal;

        private void FixedUpdate()
        {
            grounded = Physics.Raycast(transform.position, -rb.transform.up, out RaycastHit slopeHit , playerHeight * .5f + raycastExtension, groundMask);

            if (grounded)
            {
                rb.drag = groundDrag;
                hitNormal = slopeHit.normal;
            }
            else
            {
                rb.drag = 0;
            }
        }
    }
}

