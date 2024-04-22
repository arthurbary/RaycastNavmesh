using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float distance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        RaycastHit hit;

        Debug.DrawRay(transform.position, direction * distance, Color.green, 3f);
        if(Physics.Raycast(transform.position, direction, out hit, distance))
        {
            Debug.Log($" The name of the hitted object : {hit.collider.name}");
            if(hit.collider.transform == target)
            {
                transform.position += direction * 10 * Time.deltaTime;
            }
        }
    }
}
