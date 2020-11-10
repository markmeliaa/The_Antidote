using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float[] correctRotation;
    public List<int> connectedPipes;

    [SerializeField]
    bool isPlaced = false;

    int posibleRotation = 1;
    PuzleManager puzleManager;
    float[] rotations = { 0, 90, 180, 270 };

    private void Awake()
    {
        puzleManager = GameObject.Find("PuzleManager").GetComponent<PuzleManager>();
    }

    private void Start()
    {
        posibleRotation = correctRotation.Length;
        correctRotation[0] = transform.rotation.z;
        if(posibleRotation == 2)
        {
            correctRotation[1] = 180;
        }
        else
        {
            for (int i = 0; i < posibleRotation; i++)
            {
                correctRotation[i] = 90 * i;
            }
        }

        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        for (int i = 0; i < posibleRotation; i++)
        {
            if (transform.eulerAngles.z > correctRotation[i] - 1 && transform.eulerAngles.z < correctRotation[i] + 1)
            {
                isPlaced = true;
            }
        }
    }
    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));

        for (int i = 0; i < posibleRotation; i++)
        {
            if (transform.eulerAngles.z > correctRotation[i] - 1 && transform.eulerAngles.z < correctRotation[i] + 1)
            {
                isPlaced = true;
                break;
            }
            else
            {
                isPlaced = false;
            }
        }
    }
}
