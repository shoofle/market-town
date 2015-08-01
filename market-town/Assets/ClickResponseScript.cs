using UnityEngine;
using System.Collections;

public class ClickResponseScript : MonoBehaviour
{

	public Inventory inventory;

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

		//get Response Scripts
		planter = GetComponent<PlayerPlantingScriptWahoo> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButton ("Fire1")) {
			Debug.Log("Click fired");
			//check for npc's FIRST
			//check inventory holding field
			if (false) { 
			}
			else if(inventory.heldItem.item == null) //currently HAND
			{
				Debug.Log("Somethings wrong");
				// hand behavior
			}
			else if ((inventory.heldItem.item.GetComponent("PlantGrownth") as PlantGrowth)!= null) { 
				Debug.Log("Planter called");
				planter.plantToPlant = inventory.heldItem.item;
				planter.performAction = true;
			}
		}
	}
}
