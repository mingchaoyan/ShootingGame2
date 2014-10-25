using UnityEngine;
using System.Collections;

public class Win: MonoBehaviour
{

    private string intro = "Press <- and -> to move; Press Space to fire.";
    public Texture backgroud;
    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
	
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroud);
        GUI.Label(new Rect(10, 10, 500, 200), intro);
        if (Input.anyKey)
        {
            Player.score = 0;
            Player.lives = 3;
            Player.missed = 0;
            Application.LoadLevel("Level1");
        }
    }
}
