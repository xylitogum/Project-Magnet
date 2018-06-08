using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Magnet.Example
{
	public class Controller : MonoBehaviour
	{
		public static Controller instance;
		public float MoveForce = 5f;

		public Rigidbody target;
		// Use this for initialization
		void Start ()
		{
			instance = this;
		}
	
		// Update is called once per frame
		void FixedUpdate () {
			if (target)
			{
				Vector3 dir = new Vector3(
					Input.GetAxis("Horizontal"),
					Input.GetAxis("Lift"),
					Input.GetAxis("Vertical"));
				target.AddForce(dir * MoveForce, ForceMode.Acceleration);
				target.AddTorque(Vector3.up * 5f * MoveForce * Time.fixedDeltaTime * Input.GetAxis("Rotational"));
			}
		}
	}
	
}


