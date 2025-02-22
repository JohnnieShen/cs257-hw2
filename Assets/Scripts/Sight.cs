using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public float distance;
    public float angle;
    public LayerMask obstaclesLayers;
    public LayerMask objectsLayers;
    public Collider detectedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] objects = Physics.OverlapSphere(transform.position, distance, objectsLayers);
        detectedObject = null;
        for(int i = 0;i<objects.Length;i++) {
            Collider obj = objects[i];
            Vector3 directionToController = Vector3.Normalize(obj.bounds.center-transform.position);
            float angleToController = Vector3.Angle(transform.forward, directionToController);
            if (angleToController < angle) {
                if (!Physics.Linecast(transform.position, obj.bounds.center, obstaclesLayers)) {
                    Debug.DrawLine(transform.position, obj.bounds.center, Color.green);
                    detectedObject = obj;
                    break;
                }
                else {
                    Debug.DrawLine(transform.position, obj.bounds.center, Color.red);
                }
            }
        }
    }
    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);
        Vector3 rightDirection = Quaternion.Euler(0, angle, 0) * transform.forward;
        Vector3 leftDirection = Quaternion.Euler(0, -angle, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, rightDirection * distance);
        Gizmos.DrawRay(transform.position, leftDirection * distance);
    }
}
