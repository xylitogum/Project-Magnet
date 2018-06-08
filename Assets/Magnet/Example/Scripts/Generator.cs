using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Magnet.Example
{
	
	public class Generator : MonoBehaviour
	{


		public GameObject prefab;
		public bool addAsChild = false;
		public KeyCode generateKey;
		
		// Use this for initialization
		void Start () {
			
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (Input.GetKeyDown(generateKey))
			{
				GameObject obj = (GameObject)Instantiate(prefab, transform.position, transform.rotation);
				if (addAsChild) obj.transform.parent = transform;
			}
			
		}
	}
}


