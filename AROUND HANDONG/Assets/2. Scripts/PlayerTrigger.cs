using UnityEngine;
using System.Collections;
using System;

public class PlayerTrigger : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("KillingTrigger"))
        {
            Animator _animator = GetComponentInChildren<Animator>();
            if (_animator.name == "BOY") _animator.Play("BOY_DEAD");
            else _animator.Play("GIRL_DEAD");
            Time.timeScale = 0.0F;
            for(int i = 0; i < 4000; i++) { }
            Time.timeScale = 1.0F;
            Score.GameOver();
        }
    }

}

