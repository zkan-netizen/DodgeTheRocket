using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    #region -CharacterMove-
    public CharacterController PlayerControl;
    private float inputX;//left and right argumetns
    private float inputZ;//forward and backward arguments
    [SerializeField] private float Speed = 5f; // movespeed
    [SerializeField] private float rotSpeed = 720;//rotation speed
    public bool isGrounded;
    public Vector3 PlayerDirection;
    private float ySpeed;
    private JoystickManagerrr _joystickmanager;//call joystick script
    void Start()
    {
        
        _joystickmanager = GameObject.Find("JoystickCircle").GetComponent<JoystickManagerrr>();
        PlayerControl = GetComponent<CharacterController>();
    }
    void MoveCharacter()
    {
        inputX = _joystickmanager.inputHorizontal();//joystick script right and left referance
        inputZ = _joystickmanager.inputVertical();//joystick script forward and backward referance
        Vector3 PlayerDirection = new Vector3(inputX, 0, inputZ);
        PlayerDirection.Normalize();
        transform.Translate(PlayerDirection * rotSpeed * Time.deltaTime, Space.World);
        if (PlayerDirection != Vector3.zero)
        {
            // transform.forward = PlayerDirection; look character rotation simply
            Quaternion toRotation = Quaternion.LookRotation(PlayerDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotSpeed * Time.deltaTime);
        }
        PlayerControl.Move(PlayerDirection * Time.deltaTime * Speed);
    }
    void Update()
    {
        ySpeed += Physics.gravity.y * Time.deltaTime;
        MoveCharacter();
    }
    #endregion

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Jumper1")
        {
            PlayerDirection.y += Mathf.Sqrt(10 * -3f * 5);
        }

    }
}









