using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneManager : MonoBehaviour
{
    public sealed class Pair {
        public int times;
        public bool visited;

        public Pair(int x)
        {
            times = x;
            visited = false;
        }

        public void changeBool()
        {
            visited = true;
        }

        public void changeTimes()
        {
            times++;
        }
    }

    [SerializeField]
    private bool inAPuzle = false;

    private bool objectPuzle = false;

    Dictionary<string, Pair> locations;

    // Start is called before the first frame update
    void Start()
    {
        locations = new Dictionary<string, Pair>();

        for (int i = 0; i < transform.childCount; i++)
        {
            Pair newPair = new Pair(0);
            locations.Add(transform.GetChild(i).name, newPair);

            if (transform.GetChild(i).name == "KieransRoom")
                setLocationBool("KieransRoom");
            else if (transform.GetChild(i).name == "HospitalEntrance")
                setLocationBool("HospitalEntrance");
            else if (transform.GetChild(i).name == "EnterpriseEntrance")
                setLocationBool("EnterpriseEntrance");
            else if (transform.GetChild(i).name == "C3_KieransRoom")
                setLocationBool("C3_KieransRoom");
            else if (transform.GetChild(i).name == "CaveEntrance")
                setLocationBool("CaveEntrance");
            else if (transform.GetChild(i).name == "LabEntrance")
                setLocationBool("LabEntrance");
            else if (transform.GetChild(i).name == "EpilogueScene")
                setLocationBool("EpilogueScene");
        }
    }

    public bool getLocationBool(string currentLoc)
    {
        return locations[currentLoc].visited;
    }

    public int getLocationTimes(string currentLoc)
    {
        return locations[currentLoc].times;
    }

    public void setLocationBool(string currentLoc)
    {
        locations[currentLoc].changeBool();
    }

    public void setLocationTimes(string currentLoc)
    {
        locations[currentLoc].changeTimes();
    }

    public void changePuzleState()
    {
        inAPuzle = !inAPuzle;
    }

    public bool getPuzleState()
    {
        return inAPuzle;
    }

    public void changeObjectPuzleState()
    {
        objectPuzle = !objectPuzle;
    }

    public bool getObjectPuzleState()
    {
        return objectPuzle;
    }
}
