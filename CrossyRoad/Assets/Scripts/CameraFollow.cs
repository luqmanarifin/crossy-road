using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject catPlayer;
    Vector3 shouldPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        shouldPos = Vector3.Lerp(gameObject.transform.position, catPlayer.transform.position, Time.deltaTime);
        gameObject.transform.position = new Vector3(shouldPos.x, 1, shouldPos.z);
	}
}
