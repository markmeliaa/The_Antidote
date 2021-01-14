using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
            return;

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        if (!canMove)
            return;

        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.5f * horizontal * Time.deltaTime;
        position.y = position.y + 3.5f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
}
