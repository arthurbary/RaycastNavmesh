using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshObstacle))]
public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Vector3 openPosition = Vector3.down;
    [SerializeField] private float speed = 1f;
    Vector3 startPosition;
    Vector3 endPosition;

    void Start()
    {
        startPosition = transform.position;
        endPosition = transform.position + openPosition;
    }
    private void openDoor()
    {
        if(Vector3.Distance(transform.position, endPosition) > 0.01f)
        {
            transform.position += openPosition.normalized * speed * Time.deltaTime;
        }
        else
        {
            transform.position = endPosition;
        }
    }

    private void closeDoor() 
    {
        Debug.Log("THERE");

        transform.position -= openPosition.normalized * speed * Time.deltaTime;
    }
    
    private void OnTriggerStay(Collider other)
    {
        openDoor();
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.isTrigger);
        if(other.isTrigger)
        {
        closeDoor();

        }
    }
}
