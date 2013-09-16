using UnityEngine;
using System.Collections;

public class fpsController : MonoBehaviour {

	public float speed = 10.0f;
	public float mouseSpeed = 5.0f;
	public float pitchRange = 60.0f;
	public float pitchAngle = 0.0f;
	public float verticalVelocity = 0;
	public float jumpSpeed = 7.0f;
	private CharacterController cc;
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		cc	 = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		float yaw = Input.GetAxis("Mouse X") * mouseSpeed;
		transform.Rotate(0, yaw, 0);
		
		pitchAngle = pitchAngle - Input.GetAxis("Mouse Y") * mouseSpeed;
		float pitch =  Mathf.Clamp(pitchAngle, -pitchRange, pitchRange);		
		Camera.main.transform.localRotation = Quaternion.Euler(pitch, 0 , 0);
			
		//Movement
		float fwdDir = Input.GetAxis("Vertical");
		float lateralDir = Input.GetAxis("Horizontal");
		if(!cc.isGrounded){
			verticalVelocity+= Physics.gravity.y * Time.deltaTime;
		}
		
		if(cc.isGrounded && Input.GetButtonDown("Jump")){
			verticalVelocity = jumpSpeed;
		}
		
		Vector3 speedVec = new Vector3(lateralDir * speed, verticalVelocity , fwdDir * speed);
		speedVec = transform.rotation * speedVec;
		
		
		cc.Move(speedVec * Time.deltaTime);
	
	}
}
