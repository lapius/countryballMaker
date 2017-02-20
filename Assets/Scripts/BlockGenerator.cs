using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockGenerator : MonoBehaviour {

	private int rows = 1;
	public Text rowsTxt;
	private int colls = 1;
	public Text collsTxt;

	public Transform holder;
	public GameObject comicBlock;

	// Use this for initialization
	void Start () {
		rowsTxt.text = "" + rows;
		collsTxt.text = "" + colls;
	}
	
	// Update is called once per frame
	void Update () {
		//rowsTxt.text = "" + rows;
		//collsTxt.text = "" + colls;
	}

	public void AddValueRow (){
		if(rows != 99){
			rows++;
			rowsTxt.text = "" + rows;
		}
	}

	public void AddValueColl (){
		if (colls != 99) {
			colls++;
			collsTxt.text = "" + colls;
		}
	}

	public void TakeValueRow(){
		if (rows != 1) {
			rows--;
			rowsTxt.text = "" + rows;
		}
	}

	public void TakeValueColl(){
		if (colls != 1) {
			colls--;
			collsTxt.text = "" + colls;
		}
	}

	public void Generate(){
		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < colls; j++) {
				var newobj = Instantiate(comicBlock, holder.transform.position, holder.transform.rotation);
				newobj.transform.parent = holder;
				newobj.transform.position = new Vector3( holder.transform.position.x + (i * 4), holder.transform.position.y - (j * 4) ,0);
				//newobj.transform.position.y = ;
			}
		}
	}
}
