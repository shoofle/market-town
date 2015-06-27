using UnityEngine;
using System.Collections;
using System;

public class DirectDay : MonoBehaviour
{
	#region public
	// Hour of the day for Plants to access
	public int HourOfDay;

	// Minute of the Hour for Clock to access
	public int MinutesOfHour;

	// The state of the day
	public enum DayState
	{
		Dawn=4,
		Daybreak = 5,
		Day=6,
		Sunset=20,
		Evening = 21,
		Midnight=22 }
	;
	public int DaylightHours;
	#endregion


	// The color the sky should be at this hour of the day
	private Color[] colorOfDay;

	// Time taken from computer at last Hour change
	private DateTime timeAtHourChange;

	// The Directional Lights Light component
	private Light lightComponent;



	// Use this for initialization
	void Start ()
	{
		// Initialization 
		lightComponent = GetComponent<Light> ();

		timeAtHourChange = DateTime.Now;

		colorOfDay = new Color[6];
		colorOfDay [1] = new Color (0.937F, 0.839F, 1F); // 2 to 4 Dawn
		colorOfDay [2] = new Color (1F, 0.957F, 0.839F); // 4 to 6 a Daybreak
		colorOfDay [3] = new Color (1F, 0.925F, 0.839F); // 6 to 8 a Day
		colorOfDay [8] = new Color (1F, 0.839F, 0.918F); // 4 to 6 p Sunset
		colorOfDay [9] = new Color (0.976F, 0.839F, 1F); // 6 to 8 p Evening
		colorOfDay [11] = new Color (0.9F, 0.8F, 1F); // 10 to 12 p d Midnight

		// Day starts at 4, unless you sleep in or stay up through the night
		HourOfDay = 4;
		MinutesOfHour = 0;

	}
	
	// Update is called once per frame
	void Update ()
	{
		// Time Updating
		TimeSpan diff = DateTime.Now - timeAtHourChange;

		MinutesOfHour = diff.Seconds;
		if (diff.Minutes == 1) {
			timeAtHourChange = DateTime.Now;

			HourOfDay++;

			if (HourOfDay > 23) {
				HourOfDay = 0;
			}
		}

	}
}
