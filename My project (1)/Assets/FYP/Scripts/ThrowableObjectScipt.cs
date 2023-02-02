using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObjectScipt : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject dropGroudEffect;
	public bool chaseTarget;
	[SerializeField]
	private float moveSpeed = 1f;

	public GameObject TargetOChase;

    private void Update()
    {
       TargetOChase = FindObjectOfType<Enemy>().gameObject;
		if(chaseTarget)

        {
			transform.localPosition += transform.forward * moveSpeed * Time.deltaTime;
			
			transform.LookAt(TargetOChase.transform);
        }
	}
    private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Ground")
		{
			Instantiate(dropGroudEffect, this.transform.position, new Quaternion(0, 0, 0, 0));
			Destroy(gameObject, 1f);
		}
	}
}
