using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Magnet
{
	
	public class Magnetic : MonoBehaviour
	{
		public const bool DEBUG_MODE = false;
		private const float MAX_FORCE = 10f;
		public enum PolarityType
		{
			Neutral,
			North,
			South
		}

		public PolarityType Polarity = PolarityType.Neutral;
		public float MagneticPower = 1f;
		public float MinDistance = 0.001f;
		private Rigidbody attachedRigidbody;
		// Use this for initialization
		void Start ()
		{
			attachedRigidbody = GetComponentInParent<Rigidbody>();
			
			
		}
	
		// Update is called once per frame
		void FixedUpdate () {
		
		}

		void OnTriggerStay(Collider col)
		{
			if (Polarity == PolarityType.North || Polarity == PolarityType.South)
			{
				Rigidbody targetRb = col.attachedRigidbody;
				Magnetic targetMag = col.gameObject.GetComponent<Magnetic>();
				if (targetMag && targetRb)
				{
					float power = MagneticPower * targetMag.MagneticPower;
					float distance = Mathf.Max(MinDistance, Vector3.Distance(this.transform.position, targetMag.transform.position));
					float forceAmount = Mathf.Min(power / Mathf.Pow(distance, 2f), MAX_FORCE);
					Vector3 forceDir = Vector3.Normalize(this.transform.position - targetMag.transform.position);
					Vector3 force = forceDir * forceAmount;
							
					
					if (targetMag.Polarity == this.Polarity) // Same Polarity, Flip Force Direction
					{
						force *= -1f;
					}
					
					// Apply Force
					targetRb.AddForceAtPosition(force, targetMag.transform.position);
					
					// Reversed Force
					if (attachedRigidbody)
					{
						attachedRigidbody.AddForceAtPosition(-force, targetMag.transform.position);
					}
					else
					{
						if (DEBUG_MODE) Debug.LogWarning("MagneticField doesnot contain a RigidBody. Can't apply Reversed Force on it.");
					}
				}
				else
				{
					if (DEBUG_MODE) Debug.LogWarning("MagneticField found a collider without MagneticField or RigidBody.");
				}
			}
			
			
		}
	}
}

