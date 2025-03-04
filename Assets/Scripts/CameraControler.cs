using UnityEngine;

public class CameraControler : MonoBehaviour
{
    
    public Joystick rightJoystick;   
    public float rotationSpeed = 200f; 
    public enum XYZ { MouseX, MouseY, MouseXandY } // Выбор, по какой оси будет поворот
    public XYZ xy = XYZ.MouseXandY; // Ось, по умолчанию
    public float maxVert = 45f; // Ограничения поворота вокруг оси X
    public float minVert = -45f;
    private float rotationX = 0;

    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }
    void Update()
    {
        Vector2 lookInput = rightJoystick.Output;
        float rotation = lookInput.x * rotationSpeed * Time.deltaTime;
        if (xy == XYZ.MouseX)
        {
            transform.Rotate(0, rotation, 0);
        }
        else if (xy == XYZ.MouseY)
        {
            rotationX -= lookInput.y * rotationSpeed * Time.deltaTime;
            rotationX = Mathf.Clamp(rotationX, minVert, maxVert);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
        else
        {
            float delta = lookInput.x * rotationSpeed * Time.deltaTime;
            float rotationY = transform.localEulerAngles.y + delta;
            rotationX -= lookInput.y * rotationSpeed * Time.deltaTime;
            rotationX = Mathf.Clamp(rotationX, minVert, maxVert);
            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);

        }
        
        
    }
}
