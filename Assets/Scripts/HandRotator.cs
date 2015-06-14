using UnityEngine;
using System.Collections;

public class HandRotator : MonoBehaviour 
{
	[Range(0, 120)]
	[SerializeField] float maxAngle = 30;

	[SerializeField] Transform target;

	void Update () 
	{
		ChangeAngle();
	}

	void ChangeAngle()
	{
		//Move 0 to the center of screen
		float yPosition = Input.mousePosition.y - Screen.height;

		//Convert to percent
		yPosition = yPosition / Screen.height;

		float angle = maxAngle * yPosition;

		target.localRotation = Quaternion.Euler(angle, target.localRotation.y, target.localRotation.z);
	}

}
