using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDoor : MonoBehaviour
{
    [SerializeField] SpriteRenderer CorridorBackground;
    [SerializeField] Sprite NewCorridorBackground;
    [SerializeField] GameObject newDoor;
    private AudioSource doorSound;
    private DialogueManager manager;

    private void Start()
    {
        doorSound = GetComponent<AudioSource>();
        manager = GameObject.Find("DialogueBox1").GetComponent<DialogueManager>();
    }

    private void OnMouseDown()
    {
        if (!manager.InConvo)
        {
            CorridorBackground.sprite = NewCorridorBackground;
            doorSound.Play();
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            newDoor.SetActive(true);
        }
    }
}
