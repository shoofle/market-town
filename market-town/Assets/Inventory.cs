using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	// A list of things
	public inventoryObject[][] inventoryContents;

	// Things can be stacked
	private class inventoryObject{
		public string name;
		public int stackSize; // can also indicate objects that cant be used up?
	}

	// Max stack size
	public int maxStackSize;
	public int inventorySizeX;
	public int inventorySizeY;

	// The thing you are holding
	public inventoryObject heldItem;
	public inventoryObject handItem;

	public bool itemUsed;

	// Use this for initialization
	void Start () {
		inventoryContents = new inventoryObject[inventorySizeX] [inventorySizeY];
		inventoryContents [0] [0] = new inventoryObject{name = "Potato", stackSize = 2 };

		handItem = new inventoryObject{
			name = "Hands"
			,stackSize = -1
		};

		heldItem = new inventoryObject{name = "Blue Pluto Seeds", stackSize = 8 };
	}
	
	// Update is called once per frame
	void Update () {
		if (itemUsed) {
			itemUsed = false;
			if(heldItem.stackSize > 0)
				heldItem.stackSize --;
			else if(heldItem.stackSize == 0)
				heldItem = handItem;
		}
	}
}
