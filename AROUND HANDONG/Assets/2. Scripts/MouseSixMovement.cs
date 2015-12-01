using UnityEngine;
using System.Collections;

public class MouseSixMovement : MonoBehaviour {

    private float speed = 3.0f;
    private float moveY;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveY = transform.position.y + (speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, moveY, transform.position.z);

        if (moveY <= 3)
        {
            speed = -speed;
            moveY = transform.position.y + (speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, moveY, transform.position.z);
        }
        else if (moveY >= 14)
        {
            speed = -speed;
            moveY = transform.position.y + (speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, moveY, transform.position.z);
        }
    }
}
