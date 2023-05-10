using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    private float moveSpeed = 5f;
    [SerializeField]
    GameObject m_target;
    // Start is called before the first frame update
    void Start()
    {
       
        transform.LookAt(m_target.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward;
    }
}
