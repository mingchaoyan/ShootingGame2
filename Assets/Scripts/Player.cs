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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveTo = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        gameObject.transform.Translate(Vector3.right * moveTo);

        if (transform.position.x >= 7.8f)
            transform.position = new Vector3(-7.8f, transform.position.y);
        else if (transform.position.x < -7.8f)
            transform.position = new Vector3(7.8f, transform.position.y);
        Vector3 position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
        if (Input.GetKeyDown("space"))
            Instantiate(projectile, position, Quaternion.identity);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemy = (Enemy)other.gameObject.GetComponent("Enemy");
            StartCoroutine(DestroyPlayer());
            enemy.InitPositionAndSpeed();
        }
    }

    IEnumerator DestroyPlayer()
    {
        Instantiate(playerExplostion, transform.position, transform.rotation);
        lives --;
        gameObject.renderer.enabled = false;
        yield return new WaitForSeconds(1.5f);
        gameObject.renderer.enabled = true;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 200), "Score:" + score.ToString());
        GUI.Label(new Rect(10, 30, 200, 200), "Lives:" + lives.ToString());
        GUI.Label(new Rect(10, 50, 200, 200), "Missed:" + missed.ToString());
    }
}
