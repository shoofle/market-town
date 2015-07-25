using UnityEngine;
using System.Collections.Generic;

public class PlayerPlantingScriptWahoo : MonoBehaviour
{
	public GameObject plantToPlant; // A prefab of what to plant.
	public SphereCollider reticle;
	public HashSet<PlantHolder> availableDirts = new HashSet<PlantHolder> ();
	public PlantHolder currentlyTargetedDirt;

	public EnergyThingie energyslider; 

	void Start ()
	{
		reticle = GetComponent<SphereCollider> ();
		energyslider = GetComponent<EnergyThingie>();

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

		// Attempt to plant the plant we're holding.
		if (Input.GetButton ("Fire1") 
		    && (plantToPlant != null) 
		    && (currentlyTargetedDirt != null
		    && energyslider.slider.value > 0)) {
			// Check if the currently targeted dirt is available for planting
			if (currentlyTargetedDirt.IsEmpty ()) {
				// Make a new plant from the selected prefab and plant it
				GameObject plant = Instantiate (plantToPlant);
				currentlyTargetedDirt.InsertPlant (plant);
				energyslider.successfulAction = true;
			}
		}
	}

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
