using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject theMainCamera,controllingHand;
    [SerializeField]
    bool controlling;
    [SerializeField]
    Camera cam;
    [SerializeField]
    float upBorder, downBorder, leftBorder, rightBorder;
    // Start is called before the first frame update
    private void Update()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(controllingHand.transform.position);
        if (controlling)
        {
           
            if (screenPos.x < controllingHand.transform.position.x+ 1035)
            {
                theMainCamera.transform.position += 10 * Time.deltaTime * Vector3.right * -1;
            }
            else
            {
                theMainCamera.transform.position += 10 * Time.deltaTime * Vector3.right * 1;
            }

            if (screenPos.y < controllingHand.transform.position.y+ 500)
            {
                theMainCamera.transform.position += 10 * Time.deltaTime * Vector3.up * -1;
            }
            else
            {
                theMainCamera.transform.position += 10 * Time.deltaTime * Vector3.up * 1;
            }

        }
        if(theMainCamera.transform.position.x<leftBorder|| theMainCamera.transform.position.x >rightBorder || theMainCamera.transform.position.y < downBorder || theMainCamera.transform.position.y>upBorder)
        {
            theMainCamera.transform.position = new Vector2(3.38f, 4.86f);
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
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Touch")
        {
            controlling = true;
        }
    }
}
