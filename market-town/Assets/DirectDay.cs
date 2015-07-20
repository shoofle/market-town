using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DirectDay : MonoBehaviour
{
	public float MinutesPerMinute = 60F;

	// Hour of the day for Plants to access
	public float currentTime = 4F;

	public float DawnLength = 1;

	public float DuskLength = 1;

	private float SunriseTime = 6;
	public Color SunriseColor = new Color (1F, 0.957F, 0.839F);

	public Color MorningColor = new Color (1F, 0.957F, 0.839F);

	private float NoonTime = 12;
	public Color NoonColor = new Color (1F, 0.925F, 0.839F);
	
	public Color AfternoonColor = new Color (1F, 0.839F, 0.918F);
	
	private float SunsetTime = 18;
	public Color SunsetColor = new Color(1F, 0.839F, 1F);

	public Color NightColor = new Color(0F, 0F, 0F);

	// Time taken from computer at last Hour change
	private DateTime timeAtHourChange;

	// The Directional Lights Light component
	private Light lightComponent;

	private float[] times;
	private Color[] colors;



	// Use this for initialization
	void Start ()
	{
		// Initialization 
		lightComponent = GetComponent<Light> ();

		times = new float[] {
			0,
			SunriseTime - (DawnLength / 2),
			SunriseTime,
			SunriseTime + (DawnLength / 2),
			NoonTime,
			SunsetTime - (DuskLength / 2),
			SunsetTime,
			SunsetTime + (DuskLength / 2),
			24
		};

		colors = new Color[] {
			NightColor,
			NightColor,
			SunriseColor,
			MorningColor,
			NoonColor,
			AfternoonColor,
			SunsetColor,
			NightColor,
			NightColor
		};
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Time Updating
		currentTime += (Time.deltaTime / 3600) * MinutesPerMinute;

		if (currentTime > 24) {
			currentTime = 0;
		}

		int prevIndex = 0;
		for (int index = 0; index < times.Length - 1; index++) {
			if (currentTime > times[index] && currentTime < times[index+1]) {
				prevIndex = index;
			}
		}

		Color previousColor = colors[prevIndex];
		Color nextColor = colors[prevIndex+1];
		float tFactor = (currentTime - times[prevIndex]) / (times[prevIndex + 1] - times[prevIndex]);
		lightComponent.color = Color.Lerp(previousColor, nextColor, tFactor);
	}
}
