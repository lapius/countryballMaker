using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Components : MonoBehaviour {

	public GameObject flag;
	public GameObject outline;
	public GameObject size;
	public GameObject sizeText;
	public GameObject rot;
	public GameObject rotText;
	public Transform ballPanel;

	public GameObject changeThis;

	public Sprite[] flagSprites;
	public Sprite[] outlineSprites;
	public GameObject flagButtonPef;
	public GameObject outlineButtonPef;

	public List<GameObject> currentButtons = new List<GameObject>();


	void Start () {
		SizeChange ();
		RotChange ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetObject(GameObject  obj){
		changeThis = obj;
	}

	public void FlagChange(Sprite image){
		changeThis.GetComponent<Move> ().infill.GetComponent<SpriteRenderer>().sprite = image;
	}

	public void OutlineChange(Sprite image){
		changeThis.GetComponent<SpriteRenderer> ().sprite = image;
	}

	public void SizeChange(){
		float temp = size.GetComponent<Slider> ().value;
		temp = Mathf.Round (temp * 100f) / 100f;
		changeThis.transform.localScale = new Vector3(temp,temp,temp);
		sizeText.GetComponent<Text> ().text = "Size: " + temp;
	}

	public void RotChange(){
		float temp = rot.GetComponent<Slider> ().value;
		changeThis.transform.localEulerAngles = new Vector3(0,0,temp);
		rotText.GetComponent<Text> ().text = "Rotation: " + temp;
	}

	public void GenerateFlags(){
		CleanPanel ();
		for (int i = 0; i < flagSprites.Length; i++) {
			var spriteObj = Instantiate(flagButtonPef, new Vector3(0,0,0) , Quaternion.identity);
			spriteObj.transform.SetParent(ballPanel);
			spriteObj.GetComponent<Image> ().sprite = flagSprites [i];
			spriteObj.GetComponent<buttonCode> ().panel = this;
			currentButtons.Add(spriteObj);
		}

	}

	public void GenerateOutlines(){
		CleanPanel ();
		for (int i = 0; i < outlineSprites.Length; i++) {
			var spriteObj = Instantiate(outlineButtonPef, new Vector3(0,0,0) , Quaternion.identity);
			spriteObj.transform.SetParent(ballPanel);
			spriteObj.GetComponent<Image> ().sprite = outlineSprites [i];
			spriteObj.GetComponent<buttonCode> ().panel = this;
			currentButtons.Add(spriteObj);
		}
	}

	public void CleanPanel(){
		for (int i = currentButtons.Count-1; i >= 0; i--) {
			Destroy (currentButtons[i]);
		}
	}

	public void DestroyBall(){
		GameObject.Destroy (changeThis);
	}

}
