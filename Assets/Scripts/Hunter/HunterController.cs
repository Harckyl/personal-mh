using UnityEngine;

public class HunterController : MonoBehaviour
{
    public bool canMove;

    [SerializeField] Transform _hunter;
    
    [SerializeField] float _walkSpeed;
    [SerializeField] float _runSpeed;
    
    [SerializeField] Transform _camera;
    [SerializeField] CharacterController _characterController;

    [SerializeField] Transform _groundCheck;
    [SerializeField] float _groundDistance;
    [SerializeField] LayerMask _groundMask;
    
    [SerializeField] float turnSmoothTime;
    float turnSmoothVelocity;
    
    float _gravity = -9.81f;

    Vector3 velocity;
    bool _isGrounded;
    
    void Update()
    {
        if(canMove)
        {

            _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

            if (_isGrounded && velocity.y < 0)
            {
                velocity.y = -1f;
            }

            velocity.y += _gravity * Time.deltaTime;
            _characterController.Move(velocity * Time.deltaTime);
            //need to do a ground check to reset gravity's velocity to 0 when grounded

            float forward = Input.GetAxis("Forward");
            float lateral = Input.GetAxis("Lateral");

            float speed = _walkSpeed;
            if (Input.GetAxis("Run") > 0) { speed = _runSpeed; }

            Vector3 direction = new Vector3(lateral, 0, forward);

            if (direction.magnitude >= 0.1)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(_hunter.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                _hunter.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 MoveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                _characterController.Move(MoveDir * speed * direction.magnitude * Time.deltaTime);
            }

        }
    }
}
