using UnityEngine;
using System.Collections;

public class bulletThermalDetonator : MonoBehaviour {

	float lifespan = 3.0f;
	public GameObject fireEffect;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lifespan -= Time.deltaTime;
		
		if(lifespan <= 0) {
			Explode();
		}
	}
	
	void OnCollisionEnter(Collision collision) {
		
		if(collision.gameObject.name.Equals("Enemy")) {
			Debug.Log ("collided");
			Instantiate(fireEffect.gameObject, collision.transform.position, Quaternion.identity);
			Destroy(gameObject);	
			//Destroy (collision.gameObject);
		}
	}
	
	void Explode() {
		
		Destroy(gameObject);
	}
}
