using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glowingItems : MonoBehaviour
{
    [SerializeField] Sprite glowingItem;
    private SpriteRenderer item;
    private Sprite normalItem;

    // Start is called before the first frame update
    void Start()
    {
        item = GetComponent<SpriteRenderer>();
        normalItem = item.sprite;
    }

    private void OnMouseEnter()
    {
        item.sprite = glowingItem;
    }

    private void OnMouseExit()
    {
        item.sprite = normalItem;
    }

    private void OnBecameVisible()
    {
        item.sprite = normalItem;
    }
}
