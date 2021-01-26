using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGDialogue : MonoBehaviour
{
    public Conversation conver;
    public PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            DialogueManager.StartConversation(conver);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
