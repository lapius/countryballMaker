using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour {
	
	private bool isPicked;
	private bool isSelected;
	private GameObject making;
	private GameObject scripts;

	[SerializeField]
	private float counter;
	public GameObject barPrefab;
	public GameObject barCreated;
	public bool pressed;

	public GameObject infill;

	public Vector2 firstMousePos;
	public Vector3 firstObjPos;
	public Vector3 translation;
	void Start()
	{
		scripts = GameObject.FindGameObjectWithTag ("Scripts");
		making = scripts.GetComponent<BlockGenerator>().parameterPanel;
	}

	void Update()
	{
		
		if(Input.GetMouseButtonUp(0))
		{
			isPicked = false;
			//GameObject.Destroy (barCreated);
			//counter = 0;
			pressed = false;
		}
		/*
		if(Input.GetMouseButtonDown(0))
		{
			isPicked = true;
			//GameObject.Destroy (barCreated);
			//counter = 0;
			pressed = false;
		}
*/
		if(isPicked == true)
		{
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			translation = mousePos - firstMousePos;
			transform.position = firstObjPos + translation;
		}

	}

	void OnMouseDown()
	{
		if (!pressed) {

			GeneratePanel ();
			pressed = true;
		}
		firstMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		firstObjPos = transform.position;
		isPicked = true;
	}



	void GeneratePanel()
	{
		making.GetComponent<Components> ().SetObject (this.gameObject);
		making.transform.parent.gameObject.SetActive (true);
	}
		
}
