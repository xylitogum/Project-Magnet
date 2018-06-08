using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Magnet.Example
{
	
	public class Selector : MonoBehaviour {

		// Use this for initialization
		void Start () {
		
		}
	
		// Update is called once per frame
		void Update () {
		
		}

		void OnMouseDown()
		{
			Rigidbody rb = GetComponent<Rigidbody>();
			if (rb)
			{
				Controller.instance.target = rb;
			} 
		}
	}

}
