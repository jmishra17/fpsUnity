using UnityEngine;
using System.Collections;

public class HasHealth : MonoBehaviour {
	
	public float hitPoints = 100.0f;
	
	public void receiveDamage(float amt){
		Debug.Log ("Received damage: "+amt);
		hitPoints-=amt;
		if(hitPoints <= 0){
			Die();
		}
	}
	
	void Die(){
		Destroy (gameObject);	
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
