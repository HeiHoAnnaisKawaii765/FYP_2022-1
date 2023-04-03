using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject theMainCamera,controllingHand;
    [SerializeField]
    bool controlling;
    // Start is called before the first frame update
    private void Update()
    {
        if(controlling)
        {
            theMainCamera.transform.position = new Vector3(controllingHand.transform.position.x, controllingHand.transform.position.y, 0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Touch")
        {
            controlling = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Touch")
        {
            controlling = false;
        }
    }

}
