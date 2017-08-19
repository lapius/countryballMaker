using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockGenerator : MonoBehaviour {

	[Header("Block Generation")]

	private int rows = 1;
	public Text rowsTxt;
	private int colls = 1;
	public Text collsTxt;
	public Transform holder;
	public GameObject comicBlock;


	void Start () {
		rowsTxt.text = "" + rows;
		collsTxt.text = "" + colls;
	}

	//======================== Generation =============================================

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
		for (int i = 0; i < rows; i++) { //eilutes
			Debug.Log("Eilutes: " + rows);
			for (int j = 0; j < colls; j++) { //stulpeliai
				Debug.Log("Stulpeliai: " + colls);
				var newobj = Instantiate(comicBlock, holder.transform.position, holder.transform.rotation);
				Debug.Log("Spawninanm blocka");
				newobj.transform.SetParent(holder);
				newobj.transform.position = new Vector3( holder.transform.position.x + (j * newobj.GetComponent<SpriteRenderer>().bounds.size.x), holder.transform.position.y - (i * newobj.GetComponent<SpriteRenderer>().bounds.size.y) ,0);
			}
		}
	}

	//======================== End of Generation ==========================================
	[Space]
	[Header("Making comic")]
	public Sprite[] outlineSprites;
	public GameObject buttonPef;
	public GameObject spritePef;
	public Transform panelToStore;
	public GameObject parameterPanel;

	public bool making = false;

	public void GenerateOutlines(){
		for (int i = 0; i < outlineSprites.Length; i++) {
			var spriteObj = Instantiate(buttonPef, new Vector3(0,0,0) , Quaternion.identity);
			spriteObj.transform.SetParent(panelToStore);
			spriteObj.transform.localScale = new Vector3 (1, 1, 1);
			spriteObj.GetComponent<Image> ().sprite = outlineSprites [i];
			//spriteObj.GetComponent<Button> ().onClick.AddListener (() => {
			//	CreateBall (outlineSprites [i]);
			//});
			spriteObj.GetComponent<buttonCode>().SpriteSetUp(outlineSprites [i], holder);
		}

	}


	void Update () {
		
	}

	public void CreateBall (Sprite sprites){
		var spritable = Instantiate(spritePef, holder.transform.position, holder.transform.rotation);
		spritable.GetComponent<SpriteRenderer> ().sprite = sprites;
	}

}
