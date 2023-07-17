using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;


public class SetNavigationTarget : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown navigationTargetDropDown;
    [SerializeField]
    private List<Target> navigationTargetObjects = new List<Target>();

    private NavMeshPath path; //current calculated path
    private LineRenderer line;
    private Vector3 targetPosition=Vector3.zero;

    private bool lineToggle = false;

    private GameObject objB;
    private SoundController scriptSound;

    public string directionF;

    public string objectTag = "Targets";
    private GameObject[] targetObjects;
    private Renderer[] meshRenderers;

    // Start is called before the first frame update
    private void Start()
    {
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
	    line.enabled = lineToggle;
        scriptSound = GetComponent<SoundController>();
        SetCurrentNavigationTarget(0);
    }

// Update is called once per frame
    private void Update()
    {
        // if(lineToggle && targetPosition!= Vector3.zero){
        //     NavMesh.CalculatePath(transform.position,targetPosition,NavMesh.AllAreas,path);
        //     Debug.Log(path.status);
        //     // De(transform.position.ToString());
        //     // De(targetPosition.ToString());
	    //     line.positionCount = path.corners.Length;
	    //     line.SetPositions(path.corners);
        // }
        NavMesh.CalculatePath(transform.position,targetPosition,NavMesh.AllAreas,path);
        Debug.Log(path.status);
        line.positionCount = path.corners.Length;
        line.SetPositions(path.corners);
    }

    public void SetCurrentNavigationTarget(int selectedValue){
        disableAllCubes();
	    targetPosition=Vector3.zero;
	    string selectedText=navigationTargetDropDown.options[selectedValue].text;
	    Target currentTarget=navigationTargetObjects.Find(x=> x.Name.Equals(selectedText));
	    if(currentTarget!=null){
	        targetPosition=currentTarget.PositionObject.transform.position;
	    }

        MeshRenderer meshRenderer = currentTarget.PositionObject.GetComponent<MeshRenderer>();
        meshRenderer.enabled = true;

        BoxCollider boxCollider = currentTarget.PositionObject.GetComponent<BoxCollider>();
        if (boxCollider != null)
        {
            boxCollider.enabled = true;
        }

        CalculateWaypoint();
    }

    // This function is used to change the visibilty status of the navigation line.
    public void ToogleVisibility(){
	    lineToggle=!lineToggle;
	    line.enabled=lineToggle;
    }

    // This is an old method no longer used, kept for future uses.
    // private void Awake()
    // {
    //     Debug.Log("3");
    //     // Assuming you have a reference to objB in the scene
    //     objB = GameObject.FindWithTag("DirectionHandler");
    //     scriptB = objB.GetComponent<TriggerSoundController>();

    //     // Subscribe to the event in ScriptB
    //     scriptB.MyEvent += CalculateWaypoint;
    //     // Debug.Log("Alright");
    // }

    public void CalculateWaypoint()
    {
        Update();
        if (path.corners.Length >= 2)
        {
            Debug.Log("5");
            Vector3 direction = path.corners[1] - transform.position;
            direction.y = 0f; // Restrict y-axis movement

            // Calculate the angle between the current forward direction and the desired direction
            float angle = Vector3.SignedAngle(transform.forward, direction, Vector3.up);

            // Determine the direction based on the angle
            if (angle < -45f && angle > -135f)
            {
                // Turn left
                directionF = "Left";
            }
            else if (angle > 45f && angle < 135)
            {
                // Turn right
                directionF = "Right";
            }
            else if (direction.magnitude > 1f && (angle > -45f && angle < 45f) )
            {
                // Go straight
                directionF = "Forward";
            }
            else
            {
                // Go back
                directionF = "Backward";
            }

            // Debug.Log(directionF);
            // Debug.Log(angle.ToString());
            // Debug.Log(direction.ToString());
            // Debug.Log(transform.forward.ToString());
            scriptSound.playAudio(directionF);
        }
    }

    // This function is used to disable the meshrenderer & Box Collider component of all the target cubes.
    // By doing so the cubes become invisible in the AR overlay/output and do not trigger collision based events.
    // The main purpose is to make all cubes invisible and disable their collider, except for the target cube. 
    private void disableAllCubes() {
        targetObjects = GameObject.FindGameObjectsWithTag("Targets");

        if (targetObjects.Length > 0)
        {
            // Initialize the array to store the Mesh Renderer components
            meshRenderers = new Renderer[targetObjects.Length];

            // Loop through all the target objects
            for (int i = 0; i < targetObjects.Length; i++)
            {
                // Check if the current target object has a Mesh Renderer component
                meshRenderers[i] = targetObjects[i].GetComponent<Renderer>();

                // Check if the Mesh Renderer component is valid and exists on the target object
                // This disables the mesh renderer component.
                if (meshRenderers[i] != null)
                {
                    if (meshRenderers[i].enabled == true){
                        meshRenderers[i].enabled = false;
                    }
                }

                // This disables the box collider component.
                Collider collider = targetObjects[i].GetComponent<BoxCollider>();
                if (collider != null)
                {
                    collider.enabled = false;
                }
            }
        }
    }

    // This function checks if the indicator object collides with the direction collider or not.
    void OnTriggerEnter(Collider other)
    {
        // SphereCollider sphereCollider = other.GetComponent<SphereCollider>();
        if (other.CompareTag("DirectionHandler"))
        {
            CalculateWaypoint();
        }
    }
}
