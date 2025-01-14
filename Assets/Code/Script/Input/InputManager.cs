using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerControllerInput _playerControllerInput;
    private Vector2 _movementInput;
    private bool _btnInteraction;
    private bool _btnJump;
    private bool _btnAtack1;
    private bool _btnAtack2;
    private bool _btnAtack3;
    public Vector2 MovementInput { get => _movementInput; set => _movementInput = value; }
    
    public DashAbility dashAbility;
    public PuchDash dashPunchAbility;
    public FireBall fireballAbility;
    [SerializeField] public UnityEvent OnJump, OnFall;
    public string Scheme;
    public bool both;
    private void OnEnable()
    {
        if(_playerControllerInput == null) {
            _playerControllerInput = new PlayerControllerInput();
            _playerControllerInput.Locomotion.Move.performed += i => MovementInput = i.ReadValue<Vector2>();
            _playerControllerInput.Actions.Jump.performed += i => _btnJump = true;
            _playerControllerInput.Actions.Atack1.performed += i => _btnAtack1 = true;
            _playerControllerInput.Actions.Atack2.performed += i => _btnAtack2 = true;
            _playerControllerInput.Actions.Atack3.performed += i => _btnAtack3 = true;
        }
        _playerControllerInput.Enable();
        if (both) return;
        _playerControllerInput.bindingMask = new InputBinding { groups = Scheme };
    }
    private void OnDisable()
    {
        _playerControllerInput.Disable();
    }

    private void HandleMovementInput()
    {
        
    }
    private void HandleInteractionInput()
    {
        if (_btnInteraction)
        {
            _btnInteraction = false;
        }
    }
    private void HandleJumpInput()
    {
        if (_btnJump)
        {
            _btnJump = false;
            OnJump.Invoke();
        }
    }
    public void HandleAtack1()
    {
        if (_btnAtack1 )
        {
            _btnAtack1 = false;
            if (dashPunchAbility.isActiveAndEnabled&& GetComponent<LocomotionManager>().IsGrounded)
                dashPunchAbility.OnCombat();
        }
    }
    public void HandleAtack2()
    {
        if (_btnAtack2 )
        {
            _btnAtack2 = false;
            if(fireballAbility.isActiveAndEnabled&& GetComponent<LocomotionManager>().IsGrounded && fireballAbility.isReady)
                fireballAbility.OnCombat();
        }
    }
    public void HandleAtack3()
    {
        
        if (_btnAtack3 )
        {
            _btnAtack3 = false;
            if (dashAbility.isActiveAndEnabled && GetComponent<CharacterController>().isGrounded && dashAbility.isReady)
                dashAbility.OnCombat();
            
        }
    }
    public void HandleInput()
    {
        HandleAtack3();
        HandleAtack2();
        HandleAtack1();
        HandleJumpInput();
        HandleMovementInput();
        HandleInteractionInput();
    }
}
