using UnityEngine;
using System;

public class PlantGrowth : MonoBehaviour
{
	// How much time between the plant growing a stage.
	public float secondsBetweenGrowth = 60f;
	
	// The state of the plant; 0 is seed
	public enum GrowthState { Seed=0, Seedling=1, Growing=2, Adult=3 };
	public GrowthState state = GrowthState.Seed;

	// The sprites to use to render things
	public Sprite[] sprites;
	
	private DateTime timeAtStateChange;
	private SpriteRenderer spriteRenderer;
	
	// Use this for initialization
	private void Start ()
	{
		timeAtStateChange = DateTime.Now;

		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = sprites [0];
	}
	
	// Update is called once per frame
	private void Update ()
	{
		TimeSpan diff = DateTime.Now - timeAtStateChange;
		if (diff.Seconds > secondsBetweenGrowth) {
			timeAtStateChange = DateTime.Now;

			state = (GrowthState)(((int)state) + 1);

			spriteRenderer.sprite = sprites [(int)state];
		}
	}
}
