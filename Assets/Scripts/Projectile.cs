using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

public class Projectile : MonoBehaviour
{
	public float speed;
	private Transform myTransform;

	// Use this for initialization
	void Start ()
	{
		myTransform = this.gameObject.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 moveTo = Vector3.up * Time.deltaTime * speed;
		myTransform.Translate (moveTo);
		if (myTransform.position.y >= 6.2)
			Destroy (this.gameObject);
	
	}
}
