using UnityEngine;
using System.Collections;

public class PlantHolder : MonoBehaviour
{
	public GameObject whatsPlantedInMe;
	public Vector3 rootPosition;
	public float temperature = 10;
	public float moisture = 10;

	public void InsertPlant (GameObject plant)
	{
		whatsPlantedInMe = plant;
		plant.transform.parent = transform;
		plant.transform.localPosition = rootPosition;
	}

	public bool IsEmpty () {
		return whatsPlantedInMe == null;
	}
}
