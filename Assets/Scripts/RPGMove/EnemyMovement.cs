using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Transform playerTransform;
    private PlayerController playerScript;
    public bool canEnemyMove = true;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = player.GetComponent<Transform>();
        playerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!canEnemyMove)
            return;

        if (this.transform.position.y <= playerTransform.position.y)
        {
            this.GetComponent<Collider2D>().isTrigger = true;
            playerScript.canMove = false;

            if (transform.position.x <= playerTransform.position.x - 0.75)
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canEnemyMove = false;
            playerScript.canMove = true;
            this.GetComponent<Collider2D>().isTrigger = false;
        }
    }
}
