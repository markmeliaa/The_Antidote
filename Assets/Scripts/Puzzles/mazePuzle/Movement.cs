using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private float moveSpeed;
    private float dirX, dirY;

    private int choques = 0;
    public TextMeshProUGUI choquesText;
    private int collectibles = 5;
    public TextMeshProUGUI collectiblesText;
    public TextMesh winnerText;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5.0f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collectibles <= 0)
        {
            winnerText.gameObject.SetActive(true);
            collectiblesText.text = "Faltan " + collectibles + " objetos por recoger";
            return;
        }

        dirX = Input.GetAxis("Horizontal") * moveSpeed;
        dirY = Input.GetAxis("Vertical") * moveSpeed;

        choquesText.text = "Choques: " + choques;
        collectiblesText.text = "Faltan " + collectibles + " objetos por recoger";
    
        if (collectibles == 1)
            collectiblesText.text = "Falta " + collectibles + " objeto por recoger";
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(dirX, dirY, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            choques++;
        }

        if (collision.gameObject.tag == "Collectible")
        {
            collectibles--;
            Destroy(collision.gameObject);
        }
    }
}
