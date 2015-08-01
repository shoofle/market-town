using UnityEngine;
using System.Collections;

public class EnergyThingie : MonoBehaviour {
	
	private UnityEngine.UI.Slider slider;
	
	public float maximumEnergy = 1F;
	public float currentEnergy { // Okay this is needlessly confusing and tbh i'm just showing off
		// http://answers.unity3d.com/questions/556033/c-setter-getters.html try checking this if you're confused
		// http://stackoverflow.com/questions/17881091/getter-and-setter-declaration-in-net
		// just idk google getters and setters or something :X
		// sry
		get { 
			return slider.value; 
		}
		set { 
			if (value > maximumEnergy) {
				slider.value = maximumEnergy;
			} else if (value < 0F) {
				slider.value = 0F;
			} else {
				slider.value = value;
			}
		}
	}

	// Use this for initialization
	void Start () {
		slider = GameObject.Find ("EnergySlider").GetComponent<UnityEngine.UI.Slider>();
		currentEnergy = maximumEnergy;
	}
}
