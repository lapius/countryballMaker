using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonCode : MonoBehaviour {

	public GameObject spritePef;
	private Transform holderr;
	private Sprite sprited;
	public Components panel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void CreateBall (){
		var spritable = Instantiate(spritePef, new Vector3(0, 0, 0), Quaternion.identity);
		spritable.GetComponent<SpriteRenderer> ().sprite = sprited;
	}

	public void SpriteSetUp(Sprite sprite, Transform holderis){
		holderr = holderis;
		sprited = sprite;
	}

	public void ChangeFlag(){
		panel.FlagChange (this.gameObject.GetComponent<Image> ().sprite);
	}

	public void ChangeOutline(){
		panel.OutlineChange (this.gameObject.GetComponent<Image> ().sprite);
	}
}
