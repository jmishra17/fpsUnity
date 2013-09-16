using UnityEngine;
using System.Collections;

public class PerformAttackProjectile : MonoBehaviour {


	public float coolDown = 0.1f;
	public float coolDownRemaining = 0.0f;
	public GameObject projectilePrefab;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		coolDownRemaining-= Time.deltaTime;
		if(Input.GetButton("Fire2") && coolDownRemaining <= 0){
			coolDownRemaining = coolDown;
			
			Instantiate (projectilePrefab, Camera.main.transform.position + Camera.main.transform.forward, Camera.main.transform.rotation);
			
		}
	}
	
}
