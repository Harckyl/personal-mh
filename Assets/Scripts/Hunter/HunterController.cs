using UnityEngine;

public class HunterController : MonoBehaviour
{
    [SerializeField] Transform _hunter;
    [SerializeField] float _walkSpeed;
    [SerializeField] float _runSpeed;
    [SerializeField] Transform _cameraOrientation;
    [SerializeField] CharacterController _characterController;

    [SerializeField] float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    float _gravity = -9.81f;

    Vector3 velocity;
    
    void Update()
    {
        velocity.y += _gravity * Time.deltaTime;
        _characterController.Move(velocity * Time.deltaTime);
        //need to do a ground check to reset gravity's velocity to 0 when grounded

        float forward = Input.GetAxis("Forward");
        float lateral = Input.GetAxis("Lateral");

        float speed = _walkSpeed;
        if(Input.GetAxis("Run") > 0) { speed = _runSpeed; }

        Vector3 direction = new Vector3(lateral, 0, forward).normalized;
        //need to take in consideration camera orientation

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(_hunter.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        _hunter.rotation = Quaternion.Euler(0f, angle, 0f);

        _characterController.Move(direction * speed * Time.deltaTime);

    }
}
