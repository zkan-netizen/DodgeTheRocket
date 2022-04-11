using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour
{

    [SerializeField] private PlayerController _characterController;
    #region  -- Gravity --
    [Header("Gravity")]
    [SerializeField] private float Gravity = 10;
    [SerializeField] private float CurrentGravity;
    [SerializeField] private float ConstantGravity = -0.6f;
    [SerializeField] private float MaxGravity = -15;
    private Vector3 GravityDirection;
    public Vector3 GravityMovement;
    private bool isGrounded;
    void Start()
    {
        
    }
   
    private bool IsGrounded()
    {
        return _characterController.PlayerControl.isGrounded;
    }
    private void CalculateGravity()
    {
        if (IsGrounded())
        {
            CurrentGravity = ConstantGravity;
        }
        else
        {
            if (CurrentGravity > MaxGravity)
                CurrentGravity -= Gravity * Time.deltaTime;

        }
        GravityMovement = GravityDirection * -CurrentGravity;
        _characterController.PlayerControl.Move(GravityMovement + _characterController.PlayerDirection);
    }
    #endregion
    private void Awake()
    {
        GravityDirection = Vector3.down;
    }
    private void Update()
    {
        CalculateGravity();
    }

}
