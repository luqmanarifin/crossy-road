using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeadScreen : MonoBehaviour {

    public Text congrats;
    public Text highscore;
    public Button start;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowDeadScreen(int score, bool show)
    {
        if (show)
        {
            congrats.color = new Color(congrats.color.r, congrats.color.g, congrats.color.b, 255);
        }
        highscore.text = "Highscore : " + score;
        highscore.color = new Color(highscore.color.r, highscore.color.g, highscore.color.b, 255);

        var c = start.colors;
        c.normalColor = new Color(c.normalColor.r, c.normalColor.g, c.normalColor.b, 255);
        start.colors = c;
        Color colorText = start.GetComponentInChildren<Image>().color;
        start.GetComponentInChildren<Text>().color = new Color(colorText.r, colorText.g, colorText.b, 255);
    }
    void HideDeadScreen()
    {
        congrats.color = new Color(congrats.color.r, congrats.color.g, congrats.color.b, 0);
        highscore.color = new Color(highscore.color.r, highscore.color.g, highscore.color.b, 0);

        var c = start.colors;
        c.normalColor = new Color(c.normalColor.r, c.normalColor.g, c.normalColor.b, 0);
        start.colors = c;
        Color colorText = start.GetComponentInChildren<Image>().color;
        start.GetComponentInChildren<Text>().color = new Color(colorText.r, colorText.g, colorText.b, 0);
    }
    public void Restart()
    {
        HideDeadScreen();
        Application.LoadLevel(Application.loadedLevel);
    }
}
