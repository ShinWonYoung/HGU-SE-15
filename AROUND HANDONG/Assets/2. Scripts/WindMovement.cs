using UnityEngine;
using System.Collections;

public class WindMovement : MonoBehaviour {

    private float speed = -5.0f;
    private float moveX;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveX = transform.position.x + (speed * Time.deltaTime);
        transform.position = new Vector3(moveX, transform.position.y, transform.position.z);

        if (moveX <= 5)
        {
            Destroy(gameObject);
        }
    }
}
