using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

public class Projectile : MonoBehaviour
{
    public float speed;
    private Transform myTransform;
    public GameObject enemyExplosion;

    // Use this for initialization
    void Start()
    {
        myTransform = this.gameObject.transform;
    }
	
    // Update is called once per frame
    void Update()
    {
        Vector3 moveTo = Vector3.up * Time.deltaTime * speed;
        myTransform.Translate(moveTo);
        if (myTransform.position.y >= 6.2)
            Destroy(this.gameObject);
	
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Player.score += 100;
            Enemy enemy = (Enemy)other.gameObject.GetComponent("Enemy");
            enemy.minSpeed ++;
            enemy.maxSpeed ++;
            Instantiate(enemyExplosion, enemy.transform.position, enemy.transform.rotation);
            enemy.InitPositionAndSpeed();
            if (Player.score >= 500)
                Application.LoadLevel("Win");
        }
    }
}
