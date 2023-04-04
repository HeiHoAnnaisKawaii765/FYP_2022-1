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
           
            if(controllingHand.transform.position.x < theMainCamera.transform.position.x -1.3)
            {
                theMainCamera.transform.position += 10 * Time.deltaTime * Vector3.right * -1;
            }
            else
            {
                theMainCamera.transform.position += 10 * Time.deltaTime * Vector3.right * 1;
            }

            if (controllingHand.transform.position.y < theMainCamera.transform.position.y- 3)
            {
                theMainCamera.transform.position += 10 * Time.deltaTime * Vector3.up * -1;
            }
            else
            {
                theMainCamera.transform.position += 10 * Time.deltaTime * Vector3.up * 1;
            }

        }
        
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Touch")
        {
            controlling = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Touch")
        {
            controlling = true;
        }
    }

}
