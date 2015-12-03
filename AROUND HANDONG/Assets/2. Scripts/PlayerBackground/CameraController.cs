using UnityEngine;
using System.Collections;
using System;

public class CameraController : MonoBehaviour {

    public float speed = 3.0f;
    public float movX;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //스크립트가 적용된 오브젝트의 transform 의 x 값을 시간과 속도값을 곱해줌으로써
        //오른쪽으로 움직이게 함.
        movX = transform.position.x + (speed * Time.deltaTime);
        transform.position = new Vector3(movX, transform.position.y, transform.position.z);
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("PlayerTrigger"))
        {
            Animator _animator = other.gameObject.GetComponentInChildren<Animator>();
            if(_animator.name == "BOY") _animator.Play("BOY_DEAD");
            else _animator.Play("GIRL_DEAD");
            Time.timeScale = 0.0F;
            for (int i = 0; i < 4000; i++) { }
            Time.timeScale = 1.0F;
            Score.GameOver();
        }
    }
}
