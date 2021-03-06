﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 10.0f;
    public bool isFacingRight = true;
    public bool isGrounded = false;
    public GameObject groundCheck;
    public float groundCheckRadius = 0.2f;
	public float jumpForce = 1500.0f;

	private Rigidbody2D _rigidbody;
	private Animator _animator;

    public LayerMask whatIsGround;
	
    

	// Use this for initialization
	void Start () {
        _animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //GroundCheck 오브젝트가 콜라이더와 겹치는 범위를 통해 캐릭터가 땅에 있는지 확인
        //WhatIsGround 는 Player Layer를 제외한 모든 Layer이어야함. 

        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, whatIsGround);

        _animator.SetBool("Ground", isGrounded);

        float move = Input.GetAxis("Horizontal");

        _animator.SetFloat("Speed", Mathf.Abs(move));

        _rigidbody.velocity = new Vector2(move * speed, _rigidbody.velocity.y);
		_rigidbody.rotation = 0.0f;

        if (move > 0 && !isFacingRight) Flip();
        else if (move < 0 && isFacingRight) Flip();
	}

    void Update()
    {
        _rigidbody.rotation = 0.0f;
        bool jump = Input.GetKeyDown(KeyCode.Space);

        if(isGrounded && jump)
        {
            _animator.SetBool("Ground", false);
            _rigidbody.AddForce(new Vector2(0, jumpForce));
        }

    }

    void Flip()
    {
        //방향전환
        isFacingRight = !isFacingRight;     
        Vector3 _localScale = transform.localScale;
        _localScale.x *= -1;
        transform.localScale = _localScale;
    }
}
