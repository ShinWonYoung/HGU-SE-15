using UnityEngine;
using System.Collections;

public class MouseOneMovement : MonoBehaviour
{

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

        if(moveX <= 36.3)
        {
            speed = -speed;
        }
        else if(moveX >= 51.5)
        {
            speed = -speed;
        }
    }
}