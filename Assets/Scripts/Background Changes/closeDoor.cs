using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDoor : MonoBehaviour
{
    [SerializeField] SpriteRenderer CorridorBackground;
    [SerializeField] Sprite NewCorridorBackground;
    [SerializeField] GameObject newDoor;

    private void OnMouseDown()
    {
        CorridorBackground.sprite = NewCorridorBackground;
        this.gameObject.SetActive(false);
        newDoor.SetActive(true);
    }
}
