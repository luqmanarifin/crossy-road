using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {

    float lerpTime;
    float currentLerpTime;
    float perc = 1;

    public Vector3 startPos;
    public Vector3 endPos;

    public bool firstInput;
    public bool justJump;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("up") || Input.GetButtonDown("down") || Input.GetButtonDown("left") || Input.GetButtonDown("right"))
        {
            if(perc == 1)
            {
                currentLerpTime = 0;
                lerpTime = 1;
                firstInput = true;
                justJump = true;
            }
        }
        startPos = gameObject.transform.position;
        if (startPos == endPos)
        {
            if (Input.GetButtonDown("right"))
            {
                endPos = new Vector3(transform.position.x + 1, 0, transform.position.z);
            }
            if (Input.GetButtonDown("left"))
            {
                endPos = new Vector3(transform.position.x - 1, 0, transform.position.z);
            }
            if (Input.GetButtonDown("up"))
            {
                endPos = new Vector3(transform.position.x, 0, transform.position.z + 1);
            }
            if (Input.GetButtonDown("down"))
            {
                endPos = new Vector3(transform.position.x, 0, transform.position.z - 1);
            }
        }
        if (firstInput)
        {
            currentLerpTime += Time.deltaTime * 5.5f;
            perc = currentLerpTime / lerpTime;
            gameObject.transform.position = Vector3.Lerp(startPos, endPos, perc);
            if (perc > 0.8)
            {
                perc = 1;
            }
            if (Mathf.Round(perc) == 1)
            {
                justJump = false;
            }
        }
    }
}
