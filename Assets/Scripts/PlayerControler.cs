using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Joystick leftJoystick;    
    public float moveSpeed = 5f;     
    public CharacterController characterController; 

    void Update()
    {
        
        Vector2 moveInput = leftJoystick.Output;
        Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y).normalized;
        moveDirection = transform.TransformDirection(moveDirection); 
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        
       
    }
}
