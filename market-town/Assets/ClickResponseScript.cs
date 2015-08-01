using UnityEngine;
using System.Collections;

public class ClickResponseScript : MonoBehaviour
{

	public Inventory inventory;
	public GameObject InventoryUI;
	private Canvas canvas;
	// Response scripts to change value of
	public PlayerPlantingScriptWahoo planter;


	// thought about it but since the response scripts 
	// judge whether or not the action was successful
	// they should handle the energy depletion

	// Use this for initialization
	void Start ()
	{

		//get inventory
		inventory = GetComponent<Inventory> ();
		canvas = InventoryUI.GetComponent<Canvas> ();
		//get Response Scripts
		planter = GetComponent<PlayerPlantingScriptWahoo> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!canvas.enabled) {
			if (Input.GetButton ("Fire1")) {
				//check for npc's FIRST
				//check inventory holding field
				if (false) { 
				} else if (inventory.heldItem.item == null) { //currently HAND
					// hand behavior
				} else if (inventory.heldItem.item.tag == "Plant") { // Tag Enum Somewhere?
					planter.plantToPlant = inventory.heldItem.item;
					planter.performAction = true;
				}
			}
		}
	}
}
