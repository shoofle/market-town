using UnityEngine;
using System.Collections.Generic;

public class PlayerPlantingScriptWahoo : MonoBehaviour
{
	private SphereCollider reticle;
	public float energyCostPerAction = 0.1F;
	private HashSet<PlantHolder> availableDirts = new HashSet<PlantHolder> ();
	private PlantHolder currentlyTargetedDirt;
	private EnergyThingie energySlider;
	private Inventory inventory;

	void Start ()
	{
		reticle = GetComponent<SphereCollider> ();
		energySlider = GetComponent<EnergyThingie> ();
		inventory = GetComponent<Inventory> ();
	}

	// Update is called once per frame
	void Update ()
	{
		// Figure out what's the dirt closest to the center of the reticle.
		float closestDistance = float.PositiveInfinity;
		currentlyTargetedDirt = null;

		foreach (PlantHolder target in availableDirts) {
			float newDistance = Vector3.Distance (reticle.transform.position, target.transform.position);

			if (newDistance < closestDistance) {
				currentlyTargetedDirt = target;
				closestDistance = newDistance;
			}
		}
	}

	public void AttemptToPlant (GameObject plant)
	{
		if (plant != null // We've gotta be planting a plant, to plant.
			&& currentlyTargetedDirt != null // There's gotta be a dirt in the reticle.
		    && currentlyTargetedDirt.IsEmpty() // The dirt can't be occupied.
			&& energySlider.currentEnergy > 0) { // There's gotta be energy for it.
				
			// Make a new plant from the selected prefab and plant it.
			currentlyTargetedDirt.InsertPlant (Instantiate (plant));

			// Decrease the player's energy accordingly. 
			// Because we defined getters and setters in EnergyThingie, we don't need to even do function calls.
			energySlider.currentEnergy -= energyCostPerAction;

			// Remove the item from the inventory.
			inventory.DepleteCurrentItem();
		}
	}
	
	// These two methods keep track of which dirt objects are within range to be planted in.
	void OnTriggerEnter (Collider other)
	{
		PlantHolder dirt = other.GetComponent <PlantHolder> ();
		if (dirt != null) {
			availableDirts.Add (dirt);
		}
	}

	void OnTriggerExit (Collider other)
	{
		availableDirts.Remove (other.GetComponent<PlantHolder> ());
	}
}
