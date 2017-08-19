using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class ScreenshotMaking : MonoBehaviour {

	public List<GameObject> go = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Capture(){
		StartCoroutine(CapturePNG ());
	}

	public IEnumerator CapturePNG(){

		foreach (GameObject g in go) {
			g.SetActive (false);
		}

		string pathDir = Application.dataPath + "/Exported/";

		if (!Directory.Exists (pathDir)) {
			Directory.CreateDirectory (pathDir);
		}

		yield return new WaitForEndOfFrame();

		int width = Screen.width;
		int height = Screen.height;

		Texture2D tex = new Texture2D(width, height, TextureFormat.ARGB32, false);

		tex.ReadPixels(new Rect (0, 0, width, height), 0, 0);
		tex.Apply();

		byte[] bytes = tex.EncodeToPNG();
		Destroy(tex);

		string potentialName = "exported";
		int additional = 1;

		while (File.Exists(Application.dataPath + "/Exported/" + potentialName + additional.ToString() + ".png")) {
			additional++;
		}

		string path = Application.dataPath + "/Exported/" + potentialName + additional.ToString() + ".png";

		File.WriteAllBytes(path, bytes);

		yield return new WaitForEndOfFrame();
		foreach (GameObject g in go) {
			g.SetActive (true);
		}

		Debug.Log ("capture end");
		AssetDatabase.Refresh ();
	}

}
