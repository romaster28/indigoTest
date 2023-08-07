using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tester : MonoBehaviour
{
    [SerializeField] private float _force = 50;

    [SerializeField] private Transform _pointer;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        
        GetComponent<Rigidbody>().AddForceAtPosition(Vector3.forward * _force, _pointer.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
