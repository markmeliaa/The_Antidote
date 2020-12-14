using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PipeScript : MonoBehaviour
{
    public sealed class Pair
    {
        public int i;
        public int j;
        public Pair(int newi, int newj)
        {
            i = newi;
            j = newj;
        }
    };

    public List<Pair> connectedPipes;
    public int myI = 0;
    public int myJ = 0;
    public int types; //type 0 start, type 1 end, type 2 L, type 3 horizontal, type 4 +


    public Sprite waterSprite;
    public Sprite pipeSprite;
    public SpriteRenderer sp;
    public PuzleManager puzleManager;

    public bool notRotable;
    public bool connected = false;

    float[] rotations = { 0, 90, 180, 270 };
    

    private void Awake()
    {
        connectedPipes = new List<Pair>();
        sp = GetComponent<SpriteRenderer>();
        puzleManager = GameObject.Find("PuzleManager").GetComponent<PuzleManager>();
    }

    private void Start()
    {
        resetPipes();
    }

    private void Update()
    {
        if(types != 0)
        {
            int count = 0;
            for (int i = 0; i < connectedPipes.Count; i++)
            {
                count += checkPipes(i);
                if (connected)
                    break;
            }
            if (count == connectedPipes.Count)
                connected = false;
        }

        if (connected)
            sp.sprite = waterSprite;
        else
            sp.sprite = pipeSprite;
    }
    private void OnMouseDown()
    {
        if (!notRotable)
        {
            transform.Rotate(new Vector3(0, 0, 90));
        }
        connected = false;
    }

    public void resetPipes()
    {
        connected = false;
        if (!notRotable)
        {
            int rand = Random.Range(0, rotations.Length);
            transform.eulerAngles = new Vector3(0, 0, rotations[rand]);
        }

        if (types != 0)
        {
            for (int i = 0; i < connectedPipes.Count; i++)
            {
                if (types == 1)
                    notRotable = true;
                else
                    notRotable = false;

                checkPipes(i);
                if (connected)
                    break;
            }
        }
        else
        {
            connected = true;
            notRotable = true;
        }
    }

    public abstract int checkPipes(int indice);
}
