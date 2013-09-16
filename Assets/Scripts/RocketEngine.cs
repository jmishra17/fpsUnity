using UnityEngine;
using System.Collections;

public class RocketEngine : MonoBehaviour {
	
	public float speed = 10f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
		//rigidbody.AddForce(transform.forws * speed);
	}
}
