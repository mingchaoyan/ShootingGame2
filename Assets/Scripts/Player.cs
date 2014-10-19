using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed;
    public Transform projectile;

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
            enemy.InitPositionAndSpeed();
        }
    }
}
