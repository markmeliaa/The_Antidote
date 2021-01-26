using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBoxes : MonoBehaviour
{
    [SerializeField] SpriteRenderer BoxesBackground;
    [SerializeField] Sprite NewBoxesBackground;
    [SerializeField] GameObject newBoxes;
    private AudioSource boxesSound;
    [SerializeField] GameObject arrow;

    private void Start()
    {
        boxesSound = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        BoxesBackground.sprite = NewBoxesBackground;
        //boxesSound.Play();
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        arrow.SetActive(true);
        newBoxes.SetActive(true);
    }
}