using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{

	// A list of things
	public inventoryObject[] inventoryContents;

	// Things can be stacked
	public class inventoryObject
	{
		public int stackSize; // can also indicate objects that cant be used up?
		public GameObject item;
	}

	// Max stack size
	public int maxStackSize;
	public int inventorySize;

	// The thing you are holding
	public inventoryObject heldItem;
	public inventoryObject handItem;
	public bool performAction;

	// Use this for initialization
	void Start ()
	{
		//for testing
		GameObject go = GameObject.Find ("AllPlants");
		Plants plants = go.GetComponent<Plants> ();
		GameObject bluepluto = plants.plants [0];
		//end testing
		inventoryContents = new inventoryObject[inventorySize];
		inventoryContents [0] = new inventoryObject{stackSize = 2, item = bluepluto};

		handItem = new inventoryObject{
			item = null
			,stackSize = -1
		};

		heldItem = new inventoryObject{ stackSize = 8, item = bluepluto};
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (performAction) {
			performAction = false;
			if (heldItem.stackSize > 0)
				heldItem.stackSize --;
			else if (heldItem.stackSize == 0)
				heldItem = handItem;
		}
	}
}
