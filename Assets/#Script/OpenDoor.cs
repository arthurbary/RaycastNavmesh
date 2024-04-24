using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;
[RequireComponent(typeof(NavMeshObstacle))]
public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Vector3 openPosition = Vector3.down;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float delay = 3f;
    Vector3 startPosition;
    Vector3 endPosition;

    void Start()
    {
        startPosition = transform.position;
        endPosition = transform.position + openPosition;
    }
    private void openDoor()
    {
        if(Vector3.Distance(transform.position, endPosition) > 0.1f)
        {
            transform.position += openPosition.normalized * speed * Time.deltaTime;
        }
        else
        {
            transform.position = endPosition;
        }
        StartCoroutine(WaitToCloseDoor());
    }

    private void CloseDoor() 
    {
        //transform.position = startPosition;
        //Schedul
        Vector3 direction = (startPosition - endPosition).normalized;
        Vector3 test = Vector3.up * 0.01f;
        while (transform.position != startPosition)
        {
            
        }
        transform.position += direction * speed * Time.deltaTime;
        transform.position += direction * speed * Time.deltaTime;
        //transform.position += direction * speed * Time.deltaTime;
    }
    
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OPEN THE DOOR!");
        openDoor();
    }

    IEnumerator WaitToCloseDoor()
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("CLOSING THE DOOR");
        CloseDoor();
    }
}
