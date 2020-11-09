using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    float[] rotations = {0, 90, 180, 270 };
    public float correctRotation;
    public bool works;

    [SerializeField]
    bool isPlaced = false;

    private void Start()
    {
        correctRotation = transform.rotation.z;
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        if (transform.eulerAngles.z == correctRotation && works)
        {
            isPlaced = true;
        }
    }
    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));

        if(transform.eulerAngles.z == correctRotation && !isPlaced && works)
        {
            isPlaced = true;
        }
        else if (isPlaced)
        {
            isPlaced = false;
        }
    }
}
