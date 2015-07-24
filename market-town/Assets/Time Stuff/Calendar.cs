using UnityEngine;
using System.Collections;

public class Calendar : MonoBehaviour
{

	#region public
	// Hour of the day for Plants to access
	public int DayOfSeason;
	
	// Minute of the Hour for Clock to access
	public string Season;

	// Current Precipitation
	public string CurrentPrecipitation;

	// Current Temperature
	public int CurrentTemperature;

	#endregion

	#region private
	private GameObject go;
	private DirectDay light;
	#endregion


	// Use this for initialization
	void Start ()
	{
		go = GameObject.Find ("DirectionalLight");
		light = go.GetComponent<DirectDay> ();
		DayOfSeason = 1;
		Season = "Spring";
		CurrentTemperature = 50;
		CurrentPrecipitation = "Sunny";

		// Need to grab season entity here
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (light.NewDay) {
			light.NewDay = false;
			DayOfSeason++;
			if (DayOfSeason > 30) {
				DayOfSeason = 1;

				// Probably here change whatever the season entity is
				// Probably calling to the season entity
				Season = GetNewSeason ();
			}

			// These probably calling to the season entity
			// Happen after any possible season change
			CurrentTemperature = GetCurrentTemperature ();
			CurrentPrecipitation = GetCurrentPrecipitation ();

		}
	}

	private string GetNewSeason ()
	{
		return Random.Range (10, 120) % 2 == 0 ? "Spring" : "NotSpring";
	}

	private int GetCurrentTemperature ()
	{
		return Random.Range (10, 120);
	}

	private string GetCurrentPrecipitation ()
	{
		return Random.Range (10, 120) % 2 == 0? "Raining" : "Sunny";
	}


}
