using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private GameObject tower;

    Vector3 forward;
    RaycastHit hit;
    Quaternion towerRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forward = transform.TransformDirection(Vector3.forward);
        if (Input.GetKeyDown(KeyCode.T))
        {
            Vector3 towerY = hit.normal;
            Vector3 towerX = Vector3.Cross(towerY, forward);
            Vector3 towerZ = Vector3.Cross(towerX, towerY);
            towerRotation = Quaternion.LookRotation(towerZ, towerY);
            GameObject.Instantiate(tower, hit.point, towerRotation);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;        
        if (Physics.Raycast(transform.position, forward, out hit, 100))
        {
            Gizmos.DrawLine(transform.position, hit.point);
            Gizmos.color = Color.green;
            Gizmos.DrawRay(hit.point, hit.normal);
        }

        }
}
