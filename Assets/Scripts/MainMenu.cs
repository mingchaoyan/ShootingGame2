using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
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
        GUI.Label(new Rect(10, 10, 100, 100), intro);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroud);
        if (Input.anyKey)
        {
            Application.LoadLevel("Level1");
        }
    }
}
