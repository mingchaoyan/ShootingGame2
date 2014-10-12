using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float speed;

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        float moveTo = Input.GetAxis ("Horizontal") * Time.deltaTime * speed;
        gameObject.transform.Translate (Vector3.right * moveTo);

        if (transform.position.x >= 7.8f)
            transform.position = new Vector3 (-7.8f, transform.position.y);
        if (transform.position.x < -7.8f)
            transform.position = new Vector3 (7.8f, transform.position.y);
    }
}
