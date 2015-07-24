using UnityEngine;
using System.Collections;

public class Calendar : MonoBehaviour {

	#region public
	// Hour of the day for Plants to access
	public int DayOfSeason;
	
	// Minute of the Hour for Clock to access
	public string Season;

	// Current Temperature
	public int CurrentTemperature;

	// Current Precipitation
	public int CurrentPrecipitation;

	private enum Precipitations
	{
		None = 0,
		Rain = 1
	};


	#endregion

	#region private
	private GameObject go; 

	private DirectDay light;
	#endregion


	// Use this for initialization
	void Start () {
		go = GameObject.Find("DirectionalLight");
		light = go.GetComponent<DirectDay>();
		DayOfSeason = 1;
		Season = "Spring";
		CurrentTemperature = 50;
		CurrentPrecipitation = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
