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
        float moveTo = Input.GetAxis ("Horizontal") * speed;
        gameObject.transform.Translate (Vector3.right * moveTo);


    }
}
