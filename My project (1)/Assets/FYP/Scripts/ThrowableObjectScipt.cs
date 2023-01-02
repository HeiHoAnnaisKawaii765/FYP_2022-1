using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObjectScipt : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject dropGroudEffect;
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Ground")
		{
			Instantiate(dropGroudEffect, this.transform.position, new Quaternion(0, 0, 0, 0));
		}
	}
}
