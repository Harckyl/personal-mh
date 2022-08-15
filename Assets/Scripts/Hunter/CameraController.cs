using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    [SerializeField] float _speed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    void Update()
    {
        float rotateY = Input.GetAxis("CamY");
        float rotateX = Input.GetAxis("CamX");

        Vector3 newAngle = transform.eulerAngles + _speed * new Vector3(rotateY, rotateX, 0);
        if ( newAngle.x >= 0 && newAngle.x <= 90 )
        {
            transform.eulerAngles = newAngle;
        } 
        else
        {
            transform.eulerAngles += _speed * new Vector3(0, rotateX, 0);
        }
    }
}
