using UnityEngine;
using System;

public class GrowPlant : MonoBehaviour {
	// How much time between the plant growing a stage.
	public float secondsBetweenGrowth = 60f;

	// The state of the plant; 0 is seed
	public int state = 0;

	// The sprites to use to render things
	public Sprite[] sprites;

	private TimeSpan timeAtStateChange;
	private string plantname;
	private SpriteRenderer spriteRenderer;
	
	// Use this for initialization
	private void Start () {
		timeAtStateChange = DateTime.Now.TimeOfDay;
		plantname = "Blue_Pluto";

		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = sprites [0];
	}
	
	// Update is called once per frame
	private void Update () {
		TimeSpan diff = DateTime.Now.TimeOfDay - timeAtStateChange;
		if (diff.Seconds > secondsBetweenGrowth) {
			if(state < sprites.Length - 1)
			{
				// change state set texture
				state++;

				timeAtStateChange = DateTime.Now.TimeOfDay;

				spriteRenderer.sprite = sprites[state];
			}

		}
	}
}
