using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour
{
    public float starSpeed;

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
        float toMove = starSpeed * Time.deltaTime;
        transform.Translate(Vector3.down * toMove, Space.World);

        if (transform.position.y < -14f)
            transform.position = new Vector3(transform.position.x, 19.5f, 10);
    }
}
