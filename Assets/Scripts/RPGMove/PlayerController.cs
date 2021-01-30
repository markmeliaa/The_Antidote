using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    bool canMove;
    public DialogueManager dialogueManager;
    public bool caught;
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        canMove = true;
        caught = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueManager.InConvo || caught)
            canMove = false;
        else
            canMove = true;

        if (!canMove)
            return;

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        playerAnimator.SetFloat("MoveX", horizontal);
        playerAnimator.SetFloat("MoveY", vertical);
    }

    void FixedUpdate()
    {
        if (!canMove)
            return;

        Vector2 position = rigidbody2d.position;
        position.x = position.x + 4.5f * horizontal * Time.deltaTime;
        position.y = position.y + 4.5f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
}
