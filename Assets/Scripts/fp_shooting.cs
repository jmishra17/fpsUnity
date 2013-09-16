using UnityEngine;
using System.Collections;

public class fp_shooting : MonoBehaviour {
	
	public GameObject bullet_prefab;
	public float bulletSpeed = 50;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			Camera cam = Camera.main;
			GameObject bullet = (GameObject) Instantiate(bullet_prefab, cam.transform.position + (2*cam.transform.forward), cam.transform.rotation);
			bullet.rigidbody.AddForce(cam.transform.forward * bulletSpeed, ForceMode.Impulse);	
		}
	}
}
