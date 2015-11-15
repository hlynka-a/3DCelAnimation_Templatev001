using UnityEngine;
using System.Collections;

/* 

Class: move.cs

Purpose: 
- simple script to accept move input from keyboard
- object rotates to face direction of movement
- gravity not applied
- no character controller or rigidbody required
- can be replaced with your favorite movement scripts
 
 */

public class move : MonoBehaviour {

	public float speed = 1.0f;
	
	void Update () {
	
		Vector3 motion = Vector3.zero;

		motion += new Vector3(Input.GetAxis ("Horizontal"),0,0);
		motion += new Vector3 (0, 0, Input.GetAxis ("Vertical"));

		if (motion != Vector3.zero) {

			transform.rotation = Quaternion.LookRotation (motion);

			transform.Translate 
			(Vector3.forward * motion.magnitude * Time.deltaTime * speed);
		}
	}
}
