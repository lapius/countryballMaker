using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotCamera : MonoBehaviour {

	public Transform ObjectToCheck;
	public Camera Me;
	public bool Activated = false;
	public Bounds ObjectBounds;
	public bool getBounds = false;

	// Use this for initialization
	void Start () {
		Me = this.GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Activated) {
			Me.orthographicSize = ObjectBounds.size.y;
			Me.transform.position = ObjectBounds.center;
			Me.transform.position = new Vector3 (Me.transform.position.x, Me.transform.position.y, -1f);
		}
		if (getBounds) {
			GetBounds ();
			getBounds = false;
		}
	}

	private Bounds GetSizeOfBounds(){

		Quaternion currentRotation = ObjectToCheck.rotation;
		ObjectToCheck.rotation = Quaternion.Euler (0f, 0f, 0f);
		Bounds bounds = new Bounds (ObjectToCheck.position, Vector3.zero);
		foreach (SpriteRenderer renderer in GetComponentsInChildren<SpriteRenderer>()) {
			bounds.Encapsulate (renderer.bounds);
		}
		Vector3 localCeter = bounds.center - ObjectToCheck.position;
		bounds.center = localCeter;
		Debug.Log ("Local bounds of this model is " + bounds);
		ObjectToCheck.rotation = currentRotation;
		return bounds;
	}

	public void Activate(bool activate){
		Activated = activate;
	}

	public void GetBounds(){
		ObjectBounds = GetSizeOfBounds ();
	}




}
