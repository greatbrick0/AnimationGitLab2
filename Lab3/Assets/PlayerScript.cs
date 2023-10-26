using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float jumpForce = 4;
    [SerializeField]
    float speed = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector2 inputDir = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) inputDir += Vector2.up;
        if (Input.GetKey(KeyCode.S)) inputDir += Vector2.down;
        if (Input.GetKey(KeyCode.A)) inputDir += Vector2.left;
        if (Input.GetKey(KeyCode.D)) inputDir += Vector2.right;

        if (Input.GetKeyDown(KeyCode.Space)) Jump(jumpForce);

        rb.velocity = new Vector3(inputDir.x * speed, rb.velocity.y, inputDir.y * speed);
    }

    public void Jump(float amount)
    {
        rb.velocity = new Vector3(rb.velocity.x, amount, rb.velocity.z);
        transform.parent.GetComponent<Holder>().PlayJumpSound();
    }
}
