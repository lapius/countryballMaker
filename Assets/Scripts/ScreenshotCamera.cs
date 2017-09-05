using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScreenshotCamera : MonoBehaviour {

	public Transform ObjectToCheck;
	public Camera Me;
	public bool Activated = false;
	//public Bounds ObjectBounds;
	public bool getBounds = false;
	public float boundY;
	public float boundX;
	public RenderTexture rTex;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Activated) {
			/*
			boundY = ObjectToCheck.GetComponentInChildren<Renderer>().bounds.extents.y * GetComponent<BlockGenerator>().rows;
			boundX = ObjectToCheck.GetComponentInChildren<Renderer>().bounds.extents.x * GetComponent<BlockGenerator>().colls;


			Me.gameObject.GetComponent<Camera>().orthographicSize = boundY;
			Me.transform.position = ObjectToCheck.position + new Vector3(0,-boundY,0) + new Vector3(boundX,0,0) + new Vector3(0,0,-1);

			Me.transform.position = new Vector3 (Me.transform.position.x, Me.transform.position.y, -1f);
			*/
			Activate (true);
			Activated = false;
		}
	}

	public void Activate(bool activate){
		//Activated = activate;
		boundY = ObjectToCheck.GetComponentInChildren<Renderer>().bounds.extents.y * GetComponent<BlockGenerator>().rows;
		boundX = ObjectToCheck.GetComponentInChildren<Renderer>().bounds.extents.x * GetComponent<BlockGenerator>().colls;


		Me.gameObject.GetComponent<Camera>().orthographicSize = boundY;
		Me.transform.position = ObjectToCheck.position + new Vector3(0,-boundY,0) + new Vector3(boundX,0,0) + new Vector3(0,0,-1);

		Me.transform.position = new Vector3 (Me.transform.position.x, Me.transform.position.y, -1f);

		rTex = RenderTexture.GetTemporary ((int)(800 * GetComponent<BlockGenerator>().colls), (int)(600 * GetComponent<BlockGenerator>().rows));
		Me.targetTexture = rTex;
		Me.Render ();
		RenderTexture.active = rTex;

		string pathDir = Application.dataPath + "/Exported/";
		if (!Directory.Exists (pathDir)) {
			Directory.CreateDirectory (pathDir);
		}
		Texture2D tex = new Texture2D ((int)(800 * GetComponent<BlockGenerator>().colls), (int)(600 * GetComponent<BlockGenerator>().rows), TextureFormat.ARGB32, false);
		tex.ReadPixels(new Rect (0, 0, (int)(800 * GetComponent<BlockGenerator>().colls), (int)(600 * GetComponent<BlockGenerator>().rows)), 0, 0);
		tex.Apply();

		byte[] bytes = tex.EncodeToPNG();
		Destroy (tex);

		string potentialName = "exported";
		int additional = 1;

		while (File.Exists(Application.dataPath + "/Exported/" + potentialName + additional.ToString() + ".png")) {
			additional++;
		}
		string path = Application.dataPath + "/Exported/" + potentialName + additional.ToString() + ".png";
		File.WriteAllBytes(path, bytes);

	}
}
