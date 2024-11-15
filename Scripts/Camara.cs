using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject David;
    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = David.transform.position.x;
        transform.position = position;
        
    }
}
