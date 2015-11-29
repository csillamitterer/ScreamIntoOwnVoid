using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Resources : MonoBehaviour {
	public float fuel = 100;
	public float maxFuel = 100;
	public float food = 50;
	public float maxFood = 50;
	public float water = 50;
	public float maxWater = 50;
	public int population = 50;
	public int maxPopulation = 50;


	public float power = 100;
	public float lifeSupport = 50;
	public float maxLifeSupport = 50;
	public float shipFunction = 50;
	public float maxShipFunction = 50;

	public float morale = 100;
	public float maxMorale = 100;
	public float speed = 10;
	public float maxSpeed = 100;

	public float distanceRemaining = 1000;

	public float foodConsumeRate1 = 0.01f;
	public float foodConsumeRate2 = 0.05f;
	public float foodConsumeRate3 = 0.1f;
	public float foodConsumeRate4 = 0.15f;
	public float foodConsumeRate5 = 0.2f;

	public float waterConsumeRate1 = 0.01f;
	public float waterConsumeRate2 = 0.05f;
	public float waterConsumeRate3 = 0.1f;
	public float waterConsumeRate4 = 0.15f;
	public float waterConsumeRate5 = 0.2f;

	public float moraleChange1 = -1;
	public float moraleChange2 = -0.25f;
	public float moraleChange3 = 0;
	public float moraleChange4 = 0.5f;
	public float moraleChange5 = 1;


	public float foodGenerationRate = 1.0f;
	public float waterGenerationRate = 1.0f;


	public float powerPerFuel = 25;
	public float speedPerFuel = 10;

	public float LSPerPower = 1.0f;
	public float LSPerPerson = 1.0f;

	public float FoodPerPower = 0.5f;

	public float deceleration = 1.0f; 


	float fuelToPower;
	float fuelToSpeed;
	float powerToLS;
	float powerToSF;
	float foodQuantity;
	float waterQuantity;

	Slider FTP;
	Slider FTS;
	Slider PTLS;
	Slider PTSF;
	Slider FQ;
	Slider WQ;

	Slider FuelSlider;
	Slider FoodSlider;
	Slider WaterSlider;
	Slider PopSlider;
	Slider MoraleSlider;
	Slider DistanceSlider;


	// Use this for initialization
	void Start () {
		// input sliders
		FTP = GameObject.Find("FuelToPower").GetComponent<Slider>();
		FTS = GameObject.Find("FuelToSpeed").GetComponent<Slider>();
		PTLS = GameObject.Find("PowerToLS").GetComponent<Slider>();
		PTSF = GameObject.Find("PowerToSF").GetComponent<Slider>();
		FQ = GameObject.Find ("FoodQuantity").GetComponent<Slider>();
		WQ = GameObject.Find ("WaterQuantity").GetComponent<Slider>();

		//output sliders
		FuelSlider = GameObject.Find("FuelSlider").GetComponent<Slider>();
		FoodSlider = GameObject.Find("FoodSlider").GetComponent<Slider>();
		WaterSlider = GameObject.Find("WaterSlider").GetComponent<Slider>();
		PopSlider = GameObject.Find("PopSlider").GetComponent<Slider>();
		MoraleSlider = GameObject.Find("MoraleSlider").GetComponent<Slider>();
		DistanceSlider = GameObject.Find("DistanceSlider").GetComponent<Slider>();

		FuelSlider.maxValue = maxFuel;
		FoodSlider.maxValue = maxFood;
		WaterSlider.maxValue = maxWater;
		PopSlider.maxValue = maxPopulation;
		MoraleSlider.maxValue = maxMorale;
		DistanceSlider.maxValue = distanceRemaining;
	}
	
	// Update is called once per frame
	void Update () {
		PTSF.maxValue = PTLS.maxValue;

		if (!Mathf.Approximately (PTLS.normalizedValue, powerToLS)) {
			PTSF.value = PTSF.maxValue - PTLS.value;
		}
		if (!Mathf.Approximately (PTSF.normalizedValue, powerToSF)) {
			PTLS.value = PTLS.maxValue - PTSF.value;
		}


		fuelToPower = FTP.value;
		fuelToSpeed = FTS.value;
		powerToLS = PTLS.normalizedValue;
		powerToSF = PTSF.normalizedValue;

		power = fuelToPower * powerPerFuel;

		foodQuantity = FQ.value;
		waterQuantity = WQ.value;

		//update values displayed
		FuelSlider.value = fuel;
		FoodSlider.value = food;
		WaterSlider.value = water;
		PopSlider.value = population;
		MoraleSlider.value = morale;
		DistanceSlider.value = DistanceSlider.maxValue - distanceRemaining;
	}

	void LimitValues() {
		if (fuel > maxFuel) {
			fuel = maxFuel;
		}
		if (food > maxFood) {
			food = maxFood;
		}
		if (water > maxWater) {
			water = maxWater;
		}
		if (population > maxPopulation) {
			population = maxPopulation;
		}
		if (lifeSupport > maxLifeSupport) {
			lifeSupport = maxLifeSupport;
		}
		if (shipFunction > maxShipFunction) {
			shipFunction = maxShipFunction;
		}
		if (morale > maxMorale) {
			morale = maxMorale;
		}
		if (speed > maxSpeed) {
			speed = maxSpeed;
		}


		if (fuel < 0) {
			fuel = 0;
		}
		if (food < 0) {
			food = 0;
		}
		if (water < 0) {
			water = 0;
		}
		if (population < 0) {
			population = 0;
		}
		if (lifeSupport < 0) {
			lifeSupport = 0;
		}
		if (shipFunction < 0) {
			shipFunction = 0;
		}
		if (morale < 0) {
			morale = 0;
		}
		if (speed < 0) {
			speed = 0;
		}

	}

	public void TakeTurn() {
		// figure out consumption for the turn
		float fuelConsumption = fuelToPower + fuelToSpeed;

		speed += fuelToSpeed * speedPerFuel - deceleration;

		float LSGeneration = (powerToLS*power) * LSPerPower;
		float foodGeneration = foodGenerationRate + (powerToSF * power) * FoodPerPower;

		morale = 0;

		float foodConsumption;
		if (Mathf.Approximately(foodQuantity, 1)) {
			foodConsumption = population * foodConsumeRate1;
			morale += moraleChange1;
		} else if (Mathf.Approximately(foodQuantity, 2)) {
			foodConsumption = population * foodConsumeRate2;
			morale += moraleChange2;
		} else if (Mathf.Approximately(foodQuantity, 3)) {
			foodConsumption = population * foodConsumeRate3;
			morale += moraleChange3;
		} else if (Mathf.Approximately(foodQuantity, 4)) {
			foodConsumption = population * foodConsumeRate4;
			morale += moraleChange4;
		} else {
			foodConsumption = population * foodConsumeRate5;
			morale += moraleChange5;
		}

		float waterConsumption;
		if (Mathf.Approximately(waterQuantity, 1)) {
			waterConsumption = population * waterConsumeRate1;
			morale += moraleChange1;
		} else if (Mathf.Approximately(waterQuantity, 2)) {
			waterConsumption = population * waterConsumeRate2;
			morale += moraleChange2;
		} else if (Mathf.Approximately(waterQuantity, 3)) {
			waterConsumption = population * waterConsumeRate3;
			morale += moraleChange3;
		} else if (Mathf.Approximately(waterQuantity, 4)) {
			waterConsumption = population * waterConsumeRate4;
			morale += moraleChange4;
		} else {
			waterConsumption = population * waterConsumeRate5;
			morale += moraleChange5;
		}


		// population growth/shrinking from morale
		float standardisedRoll = (Random.Range (0, maxMorale) + Random.Range (0, maxMorale) + Random.Range (0, maxMorale) + Random.Range (0, maxMorale) + Random.Range (0, maxMorale)) / 5;
		float growth = morale - standardisedRoll;

		growth = growth / 10;
		population += Mathf.RoundToInt(growth);

		// update values
		fuel -= fuelConsumption;
		food += foodGeneration - foodConsumption;
		water += waterGenerationRate - waterConsumption;

		lifeSupport = LSGeneration;

		// 
		LimitValues();

		distanceRemaining -= speed;

		if (population > lifeSupport) {
			population = Mathf.FloorToInt(lifeSupport);
		}

		if (Mathf.Approximately(food, 0) || Mathf.Approximately(water, 0)) {
			population = 0;
			morale = 0;
		}

		if (food <= 0) {
			transform.root.BroadcastMessage("EndGame", "Food");
		}else if (water <= 0) {
			transform.root.BroadcastMessage("EndGame", "Water");
		}else if (population <= 0) {
			transform.root.BroadcastMessage("EndGame", "Population");
		} else if (fuel <= 0) {
			transform.root.BroadcastMessage("EndGame", "Fuel");
		} else if (distanceRemaining <= 0) {
			transform.root.BroadcastMessage("EndGame", "Win");
		}
	}
}
