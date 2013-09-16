using UnityEngine;
using System.Collections;

public class PerformAttack : MonoBehaviour {

	public float range = 100.0f;
	public float coolDown = 0.1f;
	public float coolDownRemaining = 0.0f;
	public GameObject debrisPrefab;
	public float damage = 50.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		coolDownRemaining-= Time.deltaTime;
		if(Input.GetButton("Fire1") && coolDownRemaining <= 0){
			coolDownRemaining = coolDown;
			Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
			RaycastHit hitInfo;
			if(Physics.Raycast(ray, out hitInfo, range)){
				Vector3 hitPoint = hitInfo.point;
				GameObject go = hitInfo.collider.gameObject;
				Debug.Log ("Hit object: "+go.name);
				Debug.Log ("Hit point: "+hitPoint);
				
				HasHealth h = go.GetComponent<HasHealth>();
				if(h!=null){
					h.receiveDamage(damage);	
				}
				
				if(debrisPrefab!=null){
					Instantiate(debrisPrefab, hitPoint, Quaternion.identity);
				}
				
			}
		}
	
	}
}
