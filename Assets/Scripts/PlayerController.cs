using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _jumpHeight = 2f;

    private Rigidbody2D _rBody;
    private Animator _animator;

    private Vector2 _moveDirection;
    private InputAction _moveInput;
    private InputAction _jumpInput;

    [SerializeField] private Transform _groundSensor;
    [SerializeField] private float _sensorSize = 0.3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _rBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _moveInput = InputSystem.actions["Move"];
        _jumpInput = InputSystem.actions["Jump"]; 
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = _moveInput.ReadValue<Vector2>();

        if (_moveDirection.x < 0)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
            _animator.SetBool("IsRunning", true);
        }
        else if (_moveDirection.x > 0)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }

        if(_jumpInput.WasPressedThisFrame() && IsGrounded())
        {
            Jump();
            _animator.SetBool("IsJumping", true);
        }
        _animator.SetBool("IsJumping", !IsGrounded());

    }

    void FixedUpdate()
    {
        _rBody.linearVelocityX = _moveDirection.x * _movementSpeed;
    }

    void Jump()
    {
        _rBody.AddForce(Vector2.up * Mathf.Sqrt(_jumpHeight * -2 * Physics2D.gravity.y), ForceMode2D.Impulse);
    }

    bool IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundSensor.position, _sensorSize);

        foreach(Collider2D item in colliders)
        {
            if(item.gameObject.layer == 6)
            {
                return true;
            }
        }
        return false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_groundSensor.position, _sensorSize);
        
    }
}
