using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed;
    public Transform projectile;
    public GameObject playerExplostion;

    public static int score = 0;
    public static int lives = 3;
    public static int missed = 0;

    public float projectileOffSet = 1;

    enum State
    {
        Playing,
        Explosing,
        Invisible
    }
    ;
    private State curState = State.Playing;
    private float shipMoveToScreenSpeed = 5.0f;
    private float blinkRate = 0.1f;
    private int numberOfTimeToBlink = 10;
    private int blinkCount;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (curState != State.Explosing)
        {
            float moveTo = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            gameObject.transform.Translate(Vector3.right * moveTo);

            if (transform.position.x >= 7.8f)
                transform.position = new Vector3(-7.8f, transform.position.y);
            else if (transform.position.x < -7.8f)
                transform.position = new Vector3(7.8f, transform.position.y);
            Vector3 position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + projectileOffSet);
            if (Input.GetKeyDown("space"))
                Instantiate(projectile, position, Quaternion.identity);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && curState == State.Playing)
        {
            Enemy enemy = (Enemy)other.gameObject.GetComponent("Enemy");
            StartCoroutine(DestroyPlayer());
            enemy.InitPositionAndSpeed();
        }
    }

    IEnumerator DestroyPlayer()
    {
        curState = State.Explosing;
        Instantiate(playerExplostion, transform.position, transform.rotation);
        gameObject.renderer.enabled = false;
        transform.position = new Vector3(0f, -4.8f, transform.position.z);
        yield return new WaitForSeconds(1.5f);
        lives --;
        if (lives <= 0)
        {
            lives = 3;
            score = 0;
            missed = 0;
            Application.LoadLevel("Lose");
        } else
        {
            while (transform.position.y < -3.2f)
            {
                gameObject.renderer.enabled = true;
                float toMove = shipMoveToScreenSpeed * Time.deltaTime;
                transform.position = new Vector3(0.0f, transform.position.y + toMove,
                                                 transform.position.z);
                yield return 0;
            }
            curState = State.Invisible;
            while (blinkCount < numberOfTimeToBlink)
            {
                gameObject.renderer.enabled = !gameObject.renderer.enabled;
                if (gameObject.renderer.enabled == true)
                    blinkCount++;
                yield return new WaitForSeconds(blinkRate);    
            }
            blinkCount = 0;
            curState = State.Playing;
        }

    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 200), "Score:" + score.ToString());
        GUI.Label(new Rect(10, 30, 200, 200), "Lives:" + lives.ToString());
        GUI.Label(new Rect(10, 50, 200, 200), "Missed:" + missed.ToString());
    }
}
