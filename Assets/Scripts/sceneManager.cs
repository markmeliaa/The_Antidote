using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneManager : MonoBehaviour
{
    struct Pair {
        public int times;
        public bool visited;

        public Pair(int x)
        {
            times = x;
            visited = false;
        }

        public void changeBool(bool state)
        {
            visited = state;
        }

        public void changeTimes(int newTimes)
        {
            times = newTimes;
        }
    }

    Dictionary<string, Pair> locations;
    // Start is called before the first frame update
    void Start()
    {
        locations = new Dictionary<string, Pair>();

        for (int i = 0; i < transform.childCount; i++)
        {
            Pair newPair = new Pair(0);
            locations.Add(transform.GetChild(i).name, newPair);
        }
    }

    public bool getLocationBool(string currentLoc)
    {
        return locations[currentLoc].visited;
    }

    public int GetLocationTimes(string currentLoc)
    {
        return locations[currentLoc].times;
    }

    public void setLocationBool(string currentLoc)
    {
        locations[currentLoc].changeBool(true);
    }

    public void setLocationTimes(string currentLoc, int newTimes)
    {
        locations[currentLoc].changeTimes(newTimes);
    }
}
