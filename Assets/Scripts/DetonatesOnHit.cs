using UnityEngine;
using System.Collections;

public class DetonatesOnHit : MonoBehaviour {
	
	private float speed = 10f;
	public GameObject explosionPrefab;
	public float damage = 200.0f; //damage at the centre of explosion
	public float explosionRadius = 3.0f;
	public Vector3 detonationPoint;
	
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
/*	
	void OnCollisionEnter(){
		Debug.Log("Collided");	
		Detonate();
	}
	*/
	
	void OnTriggerEnter(){
		Debug.Log("Triggered");
		Detonate();
		
	}
	
	void FixedUpdate(){
		Ray ray = new Ray(transform.position, transform.forward);
		if(Physics.Raycast(ray, speed * Time.deltaTime)){
			Detonate();	
		}
	}
	
	void Detonate(){
		Vector3 explosionPoint = transform.position + detonationPoint;
		if(explosionPrefab!=null){
			Instantiate(explosionPrefab, explosionPoint, Quaternion.identity);
		}
		DestroyObject(gameObject);
	//	GameObject.FindObjectsOfType(typeof(HasHealth));
		Collider[] colliders = Physics.OverlapSphere(explosionPoint, explosionRadius);
		foreach(Collider c in colliders){
			HasHealth h = c.GetComponent<HasHealth>();
			if(h!=null){
				float dist = Vector3.Distance(explosionPoint, c.transform.position);
				float damageRatio = 1f - (dist/explosionRadius);
				h.receiveDamage(damage * damageRatio);
			}
			
		}
	}
}
