using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnimationController : MonoBehaviour {

    Animator anim;
    public GameObject thePlayer;

    public Text score;

    public Bounce bounceScript;

    int scoreNow;
    int position;

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
        scoreNow = 0;
        position = 0;
	}
	
	// Update is called once per frame
	void Update () {
        bounceScript = thePlayer.GetComponent<Bounce>();
        if (bounceScript.justJump)
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }
        if (Input.GetButtonDown("right"))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetButtonDown("left"))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetButtonDown("up"))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            position++;
            if (position > scoreNow)
            {
                UpdateScore(position);
            }
        }
        if (Input.GetButtonDown("down"))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            position--;
        }
    }
    void UpdateScore(int newPoint)
    {
        scoreNow = newPoint;
        score.text = "Score: " + scoreNow;
    }
    void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag + "\n");
        if (other.gameObject.tag == "Obstacle")
        {
            Die();
        }
    }

    void Die()
    {
        int highscore = PlayerPrefs.GetInt("highscore", 0);
        bool show = false;
        if (scoreNow > highscore)
        {
            PlayerPrefs.SetInt("highscore", scoreNow);
            highscore = scoreNow;
            show = true;
        }
        DeadScreen deadScreen = gameObject.GetComponent<DeadScreen>();
        deadScreen.ShowDeadScreen(highscore, show);
        GameObject.Find("Level").GetComponent<Generation>().enabled = false;
        anim.SetBool("Jump", false);
        Destroy(bounceScript);
        Destroy(this);
    }
}
