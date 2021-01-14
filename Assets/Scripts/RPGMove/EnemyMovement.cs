using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Transform playerTransform;
    private PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = player.GetComponent<Transform>();
        playerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.transform.position.y <= playerTransform.position.y)
        {
            playerScript.canMove = false;

            if (transform.position.x <= playerTransform.position.x - 0.75)
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, Time.deltaTime);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            Debug.Log("ahora");
    }
}
