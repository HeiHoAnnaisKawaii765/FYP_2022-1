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


	public SpecialRewardLevelManager specialRewardLevelManager;
    private void Update()
    {
		if(FindObjectOfType<Enemy>()!=null)
        {
			TargetOChase = FindObjectOfType<Enemy>().gameObject;
				if(chaseTarget)

				{
					transform.localPosition += transform.forward * moveSpeed * Time.deltaTime;
			
					transform.LookAt(TargetOChase.transform);
				}
		}
       
		
	}
    private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Ground")
		{
			Instantiate(dropGroudEffect, this.transform.position, new Quaternion(0, 0, 0, 0));

			Destroy(gameObject, 1f);

			Destroy(gameObject, 2f);

		}
		switch(other.name)
        {
			case "0pt":specialRewardLevelManager.AddExp(0);
				break;
			case "10000pt":
				specialRewardLevelManager.AddExp(10000);
				break;
			case "20000pt":
				specialRewardLevelManager.AddExp(20000);
				break;
			case "30000pt":
				specialRewardLevelManager.AddExp(30000);
				break;
		}
	}
}
