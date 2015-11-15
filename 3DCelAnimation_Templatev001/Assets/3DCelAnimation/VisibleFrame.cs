using UnityEngine;
using System.Collections;

/*

Class: VisibleFrame.cs

Purpose:
- searches for most perpendicular frame around this gameobject,
- 	applies material of found frame to "visibleFrame," updates its position accordingly
- apply this script only to parent gameobject, it works with all immediate children of
- 	this gameobject of the user-defined layer at index 8
- to work, variable "visibleFrame" must be defined in the inspector
- NOTE: there are MANY possible variations you can try, please experiment

*/

public class VisibleFrame : MonoBehaviour {

	//in inspector, set a single frame to be visible at all times, representing object
	public GameObject visibleFrame = null;

	//optional inspector variable, you can make visible frame's position closer or farther away
	//from original position (of the frame it copies material from, not center of this gameobject)
	public float distanceFromCenter = 0f;

	//optional variables to control how often this updates: 
	//updating less makes frame less likely to flicker too often with different materials,
	//updating more helps assure frame will always be facing camera during quick movements
	float totalTime = 0f;
	public float updateTime = 1f / 12f;
	
	void Start () {

		//to start, make sure all children (except "visibleFrame") are invisible

		foreach (Transform t in this.transform) {
			t.GetComponent<Renderer>().enabled = false;
		}

		if (visibleFrame != null)
			visibleFrame.GetComponent<Renderer> ().enabled = true;
	}

	void Update () {

		totalTime += Time.deltaTime;

		if (visibleFrame == null)
			return;
		if (totalTime >= updateTime) 
			totalTime = 0f;
		else
			return;

		//in here, engine draws raycast from camera to gameobject, and records 
		//	all objects of layer 8 it passes through
		//to find the most perpendicular frame to copy to "visibleFrame,"
		//	find the hit point that is farthest away from camera
		//	(seriously, it works. Trace it out on paper to see.)

		Vector3 cameraP = Camera.main.transform.position;
		Vector3 thisP = this.transform.position;
		int layerMask = 1 << 8;
		Transform bestFrame = null;
		double bestFrameDistance = 0;

		RaycastHit[] hits 
			= Physics.RaycastAll (cameraP, (- cameraP + thisP),
		      Vector3.Distance(cameraP,thisP), layerMask);

		foreach (RaycastHit h in hits) {
			if (h.transform.parent == this.transform)
			{
				if (bestFrame == null)
				{
					bestFrame = h.transform;
					bestFrameDistance = Vector3.Distance (cameraP,h.point);
				}
				else if (Vector3.Distance (cameraP,h.point)
				         > bestFrameDistance)
				{
					bestFrame = h.transform;
					bestFrameDistance = Vector3.Distance (cameraP,h.point);
				}
			}
		}

		//update "visibleFrame" 's material and position to correspond with the most
		//	perpendicular frame. You can do a lot here to modify the outcome based on
		//	your requirements (modify position, scale, rotation, etc.)
		if (bestFrame != null) {
			visibleFrame.GetComponent<Renderer> ().sharedMaterial
				= bestFrame.GetComponent<Renderer> ().sharedMaterial;
			visibleFrame.transform.position = bestFrame.position;
			visibleFrame.transform.rotation = bestFrame.rotation;
			visibleFrame.transform.localScale = bestFrame.transform.localScale;
			visibleFrame.transform.position -= visibleFrame.transform.forward * distanceFromCenter;
		}
	}
}
