using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RedCarController : MonoBehaviour
{
	public GameManager gameManager;
	public List<AxleInfo> axleInfos;
	public float maxMotorTorque;
	public float maxSteeringAngle;
	public float brakeTorque;
	public float decelerationForce;
	public float m_Steering; // the steering value

	public void FixedUpdate()
	{
		float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * TryGetFeatureValue(CommonUsages.primary2DAxis, out _);
		for (int i = 0; i < axleInfos.Count; i++)
		{
			if (axleInfos[i].steering)
			{
				Steering(axleInfos[i], steering);
			}
			if (axleInfos[i].motor)
			{
				Acceleration(axleInfos[i], motor);
			}
			if (gameManager.brake == true)
			{
				Brake(axleInfos[i]);
			}
			ApplyLocalPositionToVisuals(axleInfos[i]);
		}

		foreach (AxleInfo axleInfo in axleInfos)
		{
			if (axleInfo.steering)
			{
                //axleInfo.leftWheel.steerAngle = steering;
				//axleInfo.rightWheel.steerAngle = steering;
			}
			if (axleInfo.motor)
			{
                //axleInfo.leftWheel.motorTorque = motor;
				//axleInfo.rightWheel.motorTorque = motor;
			}
		}
	}

    private float TryGetFeatureValue(InputFeatureUsage<Vector2> primary2DAxis, out Vector2 movementVector)
    {
        throw new NotImplementedException();
    }

    public void ApplyLocalPositionToVisuals(AxleInfo axleInfo)
	{
        axleInfo.leftWheelCollider.GetWorldPose(out Vector3 position, out Quaternion rotation);
        axleInfo.leftWheelMesh.transform.position = position;
		axleInfo.leftWheelMesh.transform.rotation = rotation;
		axleInfo.rightWheelCollider.GetWorldPose(out position, out rotation);
		axleInfo.rightWheelMesh.transform.position = position;
		axleInfo.rightWheelMesh.transform.rotation = rotation;
	}

	private void Acceleration(AxleInfo axleInfo, float motor)
	{
		if (motor != 0f)
		{
			axleInfo.leftWheelCollider.brakeTorque = 0;
			axleInfo.rightWheelCollider.brakeTorque = 0;
			axleInfo.leftWheelCollider.motorTorque = motor;
			axleInfo.rightWheelCollider.motorTorque = motor;
		}
		else
		{
			Deceleration(axleInfo);
		}
	}

	private void Deceleration(AxleInfo axleInfo)
	{
		axleInfo.leftWheelCollider.brakeTorque = decelerationForce;
		axleInfo.rightWheelCollider.brakeTorque = decelerationForce;
	}

	private void Steering(AxleInfo axleInfo, float steering)
	{
		axleInfo.leftWheelCollider.steerAngle = steering;
		axleInfo.rightWheelCollider.steerAngle = steering;
	}

	private void Brake(AxleInfo axleInfo)
	{
		axleInfo.leftWheelCollider.brakeTorque = brakeTorque;
		axleInfo.rightWheelCollider.brakeTorque = brakeTorque;
	}

	[System.Serializable]
	public class AxleInfo
	{
		public WheelCollider leftWheelCollider;
		public WheelCollider rightWheelCollider;
		public GameObject rightWheelMesh;
		public GameObject leftWheelMesh;
		public Transform rightWheel;
		public Transform leftWheel;
		public bool motor; // is this wheel attached to motor?
		public bool steering; // does this wheel apply steer angle?
		public float steerAngle;
		public float motorTorque;
	}

	public Rigidbody rb;
	public Transform redRaceStart;

	/// <summary>
	/// set trigger condition for collisions with the object this script is attached to
	/// </summary>
	/// <param name="trigger"></param>
	void OnTriggerEnter(Collider trigger)
	{
		//if (trigger.CompareTag("BluePlayer")) // if the trigger colliding with us has the tag blue Player
		//{
			//gameManager.usingCarRed = true; // set bool for using car to true
		//}
		//if (trigger.CompareTag("RedPlayer")) // if the trigger colliding with us has the tag Player
		//{
		// usingCarRed = true; // set bool for using car to true
		//}


		if (trigger.CompareTag("RedRaceStart")) // if a collider with the tag RightRaceStart interacts with our collider
		{
			rb.velocity = Vector3.zero; // set the rigidbody velocity to zero
			rb.angularVelocity = Vector3.zero;  // set the rigidbody angular velocity to zero
			transform.position = redRaceStart.position; // set the transform position of the object this script is attached to to the right race start position transform
			transform.rotation = redRaceStart.rotation; // set the transform rotation of the object this script is attached to to the right race start transform's rotation
			gameManager.LockToCarFloorBlue();
		}
		//if (trigger.CompareTag("RedRaceStart")) // if a collider with the tag LeftRaceStart interacts with our collider
		//{
		//rb.velocity = Vector3.zero;  // set the rigidbody velocity to zero
		//rb.angularVelocity = Vector3.zero;  // set the rigidbody angular velocity to zero
		//transform.position = redRaceStart.position; // set the transform position of the object this script is attached to to the left race start position transform
		//transform.rotation = redRaceStart.rotation; // set the transform rotation of the object this script is attached to to the left race start transform's rotation
		//xRInputManager.LockToCarFloorRed();
		//}
	}

	void OnTriggerExit(Collider trigger)
	{
		// disable the piece of code for mounting when we exit that trigger
		if (trigger.CompareTag("BluePlayer"))
		{
			gameManager.usingCarRed = false; // disable the using car bool
		}
		// disable the piece of code for mounting when we exit that trigger
		//if (trigger.CompareTag("RedPlayer"))
		//{
		//usingCarRed = false; // disable the using car bool
		//}
	}
}
