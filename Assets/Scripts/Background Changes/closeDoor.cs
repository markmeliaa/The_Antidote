using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDoor : MonoBehaviour
{
    [SerializeField] SpriteRenderer CorridorBackground;
    [SerializeField] Sprite NewCorridorBackground;
    [SerializeField] GameObject newDoor;
    private AudioSource doorSound;

    private void Start()
    {
        doorSound = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        CorridorBackground.sprite = NewCorridorBackground;
        doorSound.Play();
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        newDoor.SetActive(true);
    }
}
