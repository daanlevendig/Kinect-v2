using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FrontraiseScript : MonoBehaviour
{
	public Text testText1, testText2, testText3, testText4, testText5, repetitions, timer;
	public int nRepetitions = 0, maxRep = 10, hours = 0, minutes = 0, seconds = 0;
	public float realSeconds = 0;
	public bool step1Done = false, step2Done = false, startPosition = false, backStraight, handsLeveled, armStraight, armsToSide;
	//public GameObject usermap;

	public void Awake()
	{
		testText1 = GameObject.Find ("TestText 1").GetComponent<Text>();
		testText2 = GameObject.Find ("TestText 2").GetComponent<Text>();
		testText3 = GameObject.Find ("TestText 3").GetComponent<Text>();
		testText4 = GameObject.Find ("TestText 4").GetComponent<Text>();
		testText5 = GameObject.Find ("TestText 5").GetComponent<Text>();
		repetitions = GameObject.Find ("Repetitions").GetComponent<Text>();
		timer = GameObject.Find ("Timer").GetComponent<Text>();
		//kinectManager = usermap.GetComponent<KinectManager> ();
		//kinectManager.computeUserMap = true;
		//kinectManager.displayUserMap = true;
	}
	
	public void Update()	
	{
		// Instanciate Kinect Manager
		KinectManager manager = KinectManager.Instance;
		manager.computeUserMap = true;
		manager.displayUserMap = true;
		// get 1st player
		long userID = manager ? manager.GetUserIdByIndex(0) : 0;
		
		// Repetition meter
		repetitions.text = nRepetitions + " X";
		if (nRepetitions >= maxRep) {
			nRepetitions = maxRep;
			repetitions.text = "DONE!";
		}
		
		// Clock
		realSeconds += Time.deltaTime;
		if (realSeconds > 1.00) {
			seconds++;
			realSeconds = 0;
		}
		if (seconds > 59) {
			seconds = 0;
			minutes += 1;
		}
		if (minutes > 59) {
			hours += 1;
			minutes = 0;
		}
		if (timer != null) {
			timer.text = hours + ":" + (string.Format ("{0:00}", minutes)) + ":" + (string.Format ("{0:00}", seconds));
		}
		// Joints
		Vector3 bottomSpine = manager.GetJointPosition (userID, 0);
		//Vector3 midSpine = manager.GetJointPosition (userID, 1);
		//Vector3 bottomHead = manager.GetJointPosition (userID, 2);
		//Vector3 topHead = manager.GetJointPosition (userID, 3);
		Vector3 leftShoulder = manager.GetJointPosition (userID, 4);
		Vector3 leftElbow = manager.GetJointPosition (userID, 5);
		Vector3 leftHand = manager.GetJointPosition (userID, 6);
		//Vector3 leftFinger = manager.GetJointPosition (userID, 7);
		Vector3 rightShoulder = manager.GetJointPosition (userID, 8);
		Vector3 rightElbow = manager.GetJointPosition (userID, 9);
		Vector3 rightHand = manager.GetJointPosition (userID, 10);
		//Vector3 rightFinger = manager.GetJointPosition (userID, 11);
		//Vector3 leftHip = manager.GetJointPosition (userID, 12);
		//Vector3 leftKnee = manager.GetJointPosition (userID, 13);
		//Vector3 leftAnkle = manager.GetJointPosition (userID, 14);
		//Vector3 leftFoot = manager.GetJointPosition (userID, 15);
		//Vector3 rightHip = manager.GetJointPosition (userID, 16);
		//Vector3 rightKnee = manager.GetJointPosition (userID, 17);
		//Vector3 rightAnkle = manager.GetJointPosition (userID, 18);
		//Vector3 rightFoot = manager.GetJointPosition (userID, 19);
		Vector3 topSpine = manager.GetJointPosition (userID, 20);
		
		// Steps
		// Side Raise
		if (step1Done == false && startPosition == false) {
			testText1.text = "Start with your hands te the sides of your body";
		}
		else if (armStraight && backStraight && handsLeveled && startPosition && !step2Done){
			step1Done = true;
			testText1.text = "Now move your arms up, until they are at shoulder height";
		}
		else if (step1Done && armStraight && backStraight && handsLeveled && step2Done){
			testText1.text = "Good job! Now take them back down to your hips";
		}
		else if (step1Done && step2Done && armStraight && backStraight && handsLeveled && startPosition){
			nRepetitions++;
			step1Done = false;
			step2Done = false;
		}
		
		
		if ((rightHand.y > rightShoulder.y) && (leftHand.y > leftShoulder.y))
			step2Done = true;
		
		
		// Feedback
		// Straight back
		if ((Mathf.Abs (topSpine.x - bottomSpine.x)) > 0.10) {
			testText2.text = "Keep your back straight";
			backStraight = false;
		} else {
			testText2.text = "";
			backStraight = true;
		}
		// Hands leveled
		if ((Mathf.Abs (rightHand.y - leftHand.y)) > 0.10) {
			testText3.text = "Keep your hands leveled";
			handsLeveled = false;
		} else {
			testText3.text = "";
			handsLeveled = true;
		}
		// Straight arms
		if((Mathf.Abs(((rightHand.y + rightShoulder.y)/2) - rightElbow.y) > 0.05) || (Mathf.Abs(((leftHand.y + leftShoulder.y)/2) - leftElbow.y) > 0.05)) { 
			testText4.text = "Keep your arms straight";
			armStraight = false;
		} else {
			testText4.text = "";
			armStraight = true;
		}
		// Arms to the side
		if ((Mathf.Abs (rightHand.z - rightShoulder.z) > 0.10) || (Mathf.Abs (leftHand.z - leftShoulder.z) > 0.10)) {
			testText5.text = "Keep your arms to the side";
			armsToSide = false;
		} else {
			testText5.text = "";
			armsToSide = true;
		}
		// Start position
		if ((rightHand.x < (rightShoulder.x + 0.1)) && (leftHand.x > (leftShoulder.x - 0.1))) {
			startPosition = true;
		} else {
			startPosition = false;
		}
	}
}