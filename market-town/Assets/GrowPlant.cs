using UnityEngine;
using System;

public class GrowPlant : MonoBehaviour {

	// The state of the plant; 1 is seed
	private int state;
	private TimeSpan timeAtStateChange;
	private string plantname;
	public GameObject plantObject;
	
	// Use this for initialization
	private void Start () {
		this.state = 1;
		timeAtStateChange = DateTime.Now.TimeOfDay;
		plantname = "Blue_Pluto";
	}
	
	// Update is called once per frame
	private void Update () {
		TimeSpan diff = DateTime.Now.TimeOfDay - timeAtStateChange;
		if (diff.Minutes >= 1) {
			if(state != 4)
			{
				// change state set texture
				state++;

			}

		}
	}
}
