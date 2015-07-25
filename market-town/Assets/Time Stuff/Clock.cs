using UnityEngine;
using System.Collections;
using System;

public class Clock : MonoBehaviour
{
	private GameObject directGo;
	private GameObject guiTime;
	private GameObject guiTemp;

	private DirectDay light;
	private Calendar calendar;

	// ??
	void OnGUI ()
	{
		float t = light.currentTime;
		string hour = LeadingZero ((int)Math.Floor (t));
		string minute = LeadingZero ((int)((t - Math.Floor (t)) * 60));

		// Debug.Log("in on gui");
		// GUIText text = guiTime.GetComponent<GUIText> ();
		// text.text = hour + ":" + minute 
		// 	+ " " + calendar.Season 
		// 	+ " " + calendar.DayOfSeason;

		// text =  guiTemp.GetComponent<GUIText> ();

		// text.text = calendar.CurrentTemperature + "°F"
		// 	+ " " + calendar.CurrentPrecipitation;
	}

	// Adds Zeros to number if needed
	private string LeadingZero (int n)
	{
		return n.ToString ().PadLeft (2, '0');
	}

	// Use this for initialization
	void Start ()
	{
		Debug.Log("in start gui");

		directGo = GameObject.Find ("DirectionalLight");
		light = directGo.GetComponent<DirectDay> ();
		calendar = directGo.GetComponent<Calendar> ();

		guiTime = GameObject.Find ("TimeLabel");
		guiTemp = GameObject.Find ("TemperatureLabel");

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
