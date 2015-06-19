using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SelectionMenu : MonoBehaviour 
{
	void Awake()
	{

	}

	void Update()
	{
		// Instanciate Kinect Manager
		KinectManager manager = KinectManager.Instance;
		manager.computeColorMap = false;
		manager.displayColorMap = false;
		manager.DisplayMapsWidthPercent = 220f;

	}
}
