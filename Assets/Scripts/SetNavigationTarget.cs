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
    // Start is called before the first frame update
    private void Start()
    {
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
	    line.enabled = lineToggle;
    }

// Update is called once per frame
    private void Update()
    {
        if(lineToggle && targetPosition!= Vector3.zero){
            NavMesh.CalculatePath(transform.position,targetPosition,NavMesh.AllAreas,path);
            Debug.Log(path.status);
	        line.positionCount = path.corners.Length;
	        line.SetPositions(path.corners);
        }
    }

    public void SetCurrentNavigationTarget(int selectedValue){
	    targetPosition=Vector3.zero;
	    string selectedText=navigationTargetDropDown.options[selectedValue].text;
	    Target currentTarget=navigationTargetObjects.Find(x=> x.Name.Equals(selectedText));
	    if(currentTarget!=null){
	        targetPosition=currentTarget.PositionObject.transform.position;
	    }
    }


    public void ToogleVisibility(){
	    lineToggle=!lineToggle;
	    line.enabled=lineToggle;
    }
}
