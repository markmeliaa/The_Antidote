using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;

    public int nextScene;

    private void OnMouseDown()
    {
        if (SceneManager.GetActiveScene().buildIndex != nextScene)
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
       StartCoroutine(LoadLevel(nextScene));
    }

    IEnumerator LoadLevel(int nextScene)
    {
        //Play animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load scene
        SceneManager.LoadScene(nextScene);
    }
}
