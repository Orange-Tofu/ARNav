// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;

// public class random : MonoBehaviour
// {
//     [SerializeField]
//     private Camera topDownCamera;
//     [SerializeField]
//     private GameObject navTargetObject;

//     private NavMeshPath path; 
//     private LineRenderer line;

//     private bool lineToggle = false;

//     private GameObject objB;
//     private TriggerSoundController scriptB;


//     private void Start()
//     {
//         path = new NavMeshPath();
//         line = transform.GetComponent<LineRenderer>();
//     }

//     private void Update()
//     {
//         if((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began)){
//             lineToggle = !lineToggle;

//         if(lineToggle){
//             NavMesh.CalculatePath(transform.position, navTargetObject.transform.position, NavMesh.AllAreas, path);
//             line.positionCount = path.corners.Length;
//             line.SetPositions(path.corners);
//             line.enabled = true;
//         }
        
//         }
//     }

//     private void Awake()
//     {
//         // Assuming you have a reference to objB in the scene
//         objB = GameObject.Find("DirectionCollider");
//         scriptB = objB.GetComponent<TriggerSoundController>();

//         // Subscribe to the event in ScriptB
//         scriptB.MyEvent += CalculateWaypoint;
//     }

//     public void CalculateWaypoint()
//     {
//         if (path.corners.Length >= 2)
//         {
//             Vector3 direction = path.corners[1] - transform.position;
//             direction.y = 0f; // Restrict y-axis movement

//             // Calculate the angle between the current forward direction and the desired direction
//             float angle = Vector3.SignedAngle(transform.forward, direction, Vector3.up);

//             // Determine the direction based on the angle
//             if (angle < -45f)
//             {
//                 // Turn left
//                 Debug.Log("Turn left");
//             }
//             else if (angle > 45f)
//             {
//                 // Turn right
//                 Debug.Log("Turn right");
//             }
//             else if (direction.magnitude > 1f)
//             {
//                 // Go straight
//                 Debug.Log("Go straight");
//             }
//             else
//             {
//                 // Go back
//                 Debug.Log("Go back");
//             }
//         }
//         // Call the playAudio function in ScriptB
//         scriptB.playAudio();
//     }

// }
