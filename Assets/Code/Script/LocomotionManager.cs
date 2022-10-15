using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LocomotionManager : MonoBehaviour
{
    private InputManager inputManager;

    [Header("Locomotion Config")]
    [Header("MovementInformations")]
    [SerializeField] private float yMovement = -1;
    [SerializeField] private float _rotationSpeed = 0.5f;

    [Header("JumpInformations")]
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _timeToPeek;

    [SerializeField] private CharacterController chrController;
    [SerializeField] private float movementSpeed = 2;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float _gravity, _jumpSpeed;
    private bool isJumping;
    private bool isInteracting;
    public bool IsJumping { get => isJumping; set => isJumping = value; }
    public bool IsInteracting { get => isInteracting; set => isInteracting = value; }
    public bool IsGrounded { get => isGrounded; set => isGrounded = value; }

    [SerializeField] private UnityEvent OnJump, OnFall;

    

    void Start()
    {
        inputManager = GetComponent<InputManager>();
        chrController = GetComponent<CharacterController>();
        _gravity = 2 * _maxHeight / (_timeToPeek * _timeToPeek);
        _jumpSpeed = _gravity * _timeToPeek;
    }

    public void HandleJump()
    {
        if (IsGrounded)
        {
            yMovement = _jumpSpeed;
            OnJump.Invoke();
        }
    }
    private void HandleFall()
    {
        IsGrounded = chrController.isGrounded;
        if (IsGrounded)
        {
            yMovement = -1f;
        }
        else
        {
            if (!IsJumping && !IsInteracting)
            {
                OnFall.Invoke();
            }
            yMovement -= _gravity * Time.fixedDeltaTime;
        }
    }

    private void HandleMovement()
    {
        Vector3 movement;
        float vertical = inputManager.MovementInput.y;
        float horizontal = inputManager.MovementInput.x;

        movement = Camera.main.transform.forward* vertical;
        movement = movement + Camera.main.transform.right * horizontal;

        movement = movement.normalized * movementSpeed;
        movement.y = yMovement;

        chrController.Move(movement * Time.fixedDeltaTime);
    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;

        targetDirection = Camera.main.transform.forward * inputManager.MovementInput.y;
        targetDirection = targetDirection + Camera.main.transform.right * inputManager.MovementInput.x;


        targetDirection.Normalize();
        targetDirection.y = 0;
        if (targetDirection == Vector3.zero) targetDirection = transform.forward;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.fixedDeltaTime);
        transform.rotation = playerRotation;
    }
    public void HandleLocomotion()
    {   
        HandleRotation();
        HandleMovement();
        HandleFall();
    }
}
