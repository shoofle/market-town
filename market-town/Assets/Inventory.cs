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
	public inventoryObject handItem = new inventoryObject{ item = null, stackSize = -1};

	// Use this for initialization
	void Start ()
	{
		//for testing
		Plants plants = GameObject.Find ("AllPlants").GetComponent<Plants> ();
		GameObject bluepluto = plants.plants [0];

		inventoryContents = new inventoryObject[inventorySize];
		inventoryContents [0] = new inventoryObject{stackSize = 2, item = bluepluto};

		heldItem = new inventoryObject{ item = bluepluto, stackSize = 8};
		// let's be real, all of this is for testing at the moment
	}
	
	// Update is called once per frame
	public void DepleteCurrentItem ()
	{
		if (heldItem.stackSize > 0) {
			heldItem.stackSize --;
		} else if (heldItem.stackSize == 0) {
			heldItem = handItem;
		}
	}
}
