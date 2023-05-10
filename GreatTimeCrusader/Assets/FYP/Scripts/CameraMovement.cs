using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float camMoveSpeed = 1f;
    float Hthr;
    float Vthr;

    private void Start()
    {
        Hthr = 0;
        Vthr = 0;
    }

    void Update()
    {
        transform.position += transform.up * Hthr * camMoveSpeed * Time.deltaTime;
        transform.position += transform.right * Vthr * camMoveSpeed * Time.deltaTime;
        if (Hthr > 5)
        {
            Hthr = 5;
        }
        else if (Hthr < -5)
        {
            Hthr = -5;
        }

        if (Vthr > 5)
        {
            Vthr = 5;
        }
        else if (Vthr < -5)
        {
            Vthr = -5;
        }
    }
    public void UpValueAdd()
    {
        Hthr += 1;
    }
    public void DownValueAdd()
    {
        Hthr -= 1;
    }
    public void LeftValueAdd()
    {
        Vthr -= 1;
    }
    public void RightValueAdd()
    {
        Vthr += 1;
    }
    public void StopMoving()
    {
        Hthr = 0;
        Vthr = 0;
    }

}
