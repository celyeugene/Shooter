using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTest : MonoBehaviour
{

    public float shootingRange = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookForward();
    }

    void LookForward()
    {
        Vector3 direction = transform.forward;
        Ray ray = new Ray(transform.position, direction);

        Debug.DrawRay(ray.origin, ray.direction * shootingRange, Color.red); // Отрисовка луча в сцене

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, shootingRange))
        {
            
                Debug.Log("Hit player!");
                
        }
    }
}
