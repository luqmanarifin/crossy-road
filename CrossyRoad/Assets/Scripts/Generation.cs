using UnityEngine;
using System.Collections;

public class Generation : MonoBehaviour
{

    public GameObject blockWater;
    public GameObject blockRoad;
    public GameObject blockGrass;
    public GameObject blockHell;

    GameObject[] things;

    int id;
    int disPlayer = 11;
    int width;

    Vector3 intPos = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start()
    {
        things = new GameObject[3];
        things[0] = blockWater;
        things[1] = blockRoad;
        things[2] = blockGrass;
        width = 11;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("up"))
        {

            id = Random.Range(0, 3);
            int len = Random.Range(1, 7);
            for (int i = 0; i < len; i++)
            {
                disPlayer++;
                for (int j = -width / 2; j <= width / 2; j++) {
                    intPos = new Vector3(j, 0, disPlayer);
                    int random = Random.Range(1, 5);
                    if (random == 4)
                    {
                        GameObject ins = Instantiate(blockHell) as GameObject;
                        ins.transform.position = intPos;
                    }
                    else
                    {
                        GameObject ins = Instantiate(things[id]) as GameObject;
                        ins.transform.position = intPos;
                    }
                }
                for(int j = 1; j <= 2; j++)
                {
                    intPos = new Vector3(width/2 + j, 0, disPlayer);
                    GameObject ins = Instantiate(blockHell) as GameObject;
                    ins.transform.position = intPos;

                    intPos = new Vector3(-width / 2 - j, 0, disPlayer);
                    GameObject ins2 = Instantiate(blockHell) as GameObject;
                    ins2.transform.position = intPos;
                }
            }
        }
    }
}
