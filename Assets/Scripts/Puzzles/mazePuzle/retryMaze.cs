using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class retryMaze : MonoBehaviour
{
    public GameObject currentPuzzle;

    private void OnMouseDown()
    {
        RepeatMaze();
    }

    public void RepeatMaze()
    {
        Transform gameArea = currentPuzzle.transform.Find("Game Area").transform;

        if (!gameArea.Find("YouWin").gameObject.activeSelf)
        {
            gameArea.Find("Player").GetComponent<Movement>().resetValues();
            gameArea.Find("Maze Generator").GetComponent<Maze>().resetValues(gameArea.gameObject);
        }

        Transform collectibles = gameArea.transform.Find("Collectibles").transform;

        for (int i = 0; i < collectibles.childCount; i++)
        {
            if (!collectibles.GetChild(i).gameObject.activeSelf)
                collectibles.GetChild(i).gameObject.SetActive(true);
        }
    }
}
