using UnityEngine;
using System.Collections;

public class ExitInventory : MonoBehaviour {

	public GameObject InventoryUI;
	private Canvas canvas;
	// Use this for initialization
	void Start () {

	}
	
	void OnMouseUpAsButton () {
		InventoryUI = GameObject.Find ("InventoryCanvas");
			canvas = InventoryUI.GetComponent<Canvas>();
		    canvas.enabled = false;
	}
}
