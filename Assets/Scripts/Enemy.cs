using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
		public float minSpeed;
		public float maxSpeed;
		private float currentSpeed;

		float x, y, z;

		// Use this for initialization
		void Start ()
		{
				InitPositionAndSpeed ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				float toMove = currentSpeed * Time.deltaTime;
				transform.Translate (Vector3.down * toMove);
				if (transform.position.y < -4.5)
						InitPositionAndSpeed ();
	
		}
		public void InitPositionAndSpeed ()
		{
				currentSpeed = Random.Range (minSpeed, maxSpeed);
				x = Random.Range (-8.5f, 8.5f);
				y = 6.5f;
				transform.position = new Vector3 (x, y, z);
		}
}
