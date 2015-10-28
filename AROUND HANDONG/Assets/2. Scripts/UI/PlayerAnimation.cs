using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
    /*
    private bool _isFacingRight;
    private CharacterController2D _controller;   //the code that has the values.
    private float _normalizedHorizontalSpeed; // 1 or -1 left right

    public float MaxSpeed = 8;
    public float SpeedAccelerationOnGround = 10f; //how quickly the player's speed can change
    public float SpeedAccelerationInAir = 5f;

    public Animator Animator;

    public void Start()
    {
        _controller = GetComponent<CharacterController2D>();
        _isFacingRight = transform.localScale.x > 0; //we're facing right if not flipped
    }

    public void Update()
    {
        HandleInput(); //change _normalizedHorizontalSpeed to 1 -1 or 0 depending on what the player is pressing

        var movementFactor = _controller.State.IsGrounded ? SpeedAccelerationOnGround : SpeedAccelerationInAir;
        _controller.SetHorizontalForce(Mathf.Lerp(_controller.Velocity.x, _normalizedHorizontalSpeed * MaxSpeed, Time.deltaTime * movementFactor));

        Animator.SetBool("IsGrounded", _controller.State.IsGrounded);
        Animator.SetFloat("Speed", Mathf.Abs(_controller.Velocity.x) / MaxSpeed);

    }

    public void HandleInput()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _normalizedHorizontalSpeed = 1;
            if (!_isFacingRight)
                flip();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _normalizedHorizontalSpeed = -1;
            if (_isFacingRight)
                flip();
        }
        else
        {
            _normalizedHorizontalSpeed = 0;
        }

        if (_controller.CanJump && Input.GetKeyDown(KeyCode.Space))
        {
            _controller.Jump();
        }

    }

    private void flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _isFacingRight = transform.localScale.x > 0;
    }

    */
}
