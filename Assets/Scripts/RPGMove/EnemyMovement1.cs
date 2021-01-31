using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement1 : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Transform playerTransform;
    private PlayerController playerScript;
    public bool canEnemyMove = true;
    private Animator reclutaAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = player.GetComponent<Transform>();
        playerScript = player.GetComponent<PlayerController>();
        reclutaAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!canEnemyMove)
            return;

        if (this.transform.position.y <= playerTransform.position.y)
        {
            reclutaAnimator.SetBool("Moving", true);
            this.GetComponent<Collider2D>().isTrigger = true;
            playerScript.playerAnimator.SetFloat("MoveY", 0);
            playerScript.playerAnimator.SetFloat("MoveX", 0);
            playerScript.caught = true;

            if (transform.position.x <= playerTransform.position.x - 0.75)
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, Time.deltaTime * 0.75f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canEnemyMove = false;
            playerScript.caught = false;
            this.GetComponent<Collider2D>().isTrigger = false;
            reclutaAnimator.SetBool("Moving", false);
        }
    }
}
