using UnityEngine;
using System.Collections;

public class EnergyThingie : MonoBehaviour {

	private  GameObject EnergySlider;
	public UnityEngine.UI.Slider slider;
	public bool successfulAction;
	// Use this for initialization
	void Start () {
		EnergySlider = GameObject.Find ("EnergySlider");
		slider = EnergySlider.GetComponent<UnityEngine.UI.Slider>();
		slider.value = 1F;
		successfulAction = false;
	}
	
	// Update is called once per frame
	void Update () {
		// could be more complicated based on action?
		if (successfulAction) {
			slider.value -= .1F;
			successfulAction = false;
		}
		if (slider.value < slider.minValue)
			slider.value = slider.minValue;
	}
}
