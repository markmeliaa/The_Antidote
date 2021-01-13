using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private float moveSpeed;
    private float dirX, dirY;
    private float startX;
    private float startY;

    private int choques = 0;
    public TextMeshProUGUI choquesText;
    private int collectibles = 5;
    public TextMeshProUGUI collectiblesText;
    public TextMesh winnerText;
    [SerializeField] retryMaze retrymaze;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5.0f;
        rb = GetComponent<Rigidbody>();
        startX = rb.transform.position.x;
        startY = rb.transform.position.y;
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

        if (choques >= 10)
        {
            retrymaze.RepeatMaze();
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
            collision.gameObject.SetActive(false);
        }
    }

    public void resetValues()
    {
        collectibles = 5;
        choques = 0;
        collectiblesText.text = "Faltan " + collectibles + "objetos por recoger";
        choquesText.text = "Choques: " + choques;
        rb.transform.position = new Vector3(startX, startY, 0);
    }
}
