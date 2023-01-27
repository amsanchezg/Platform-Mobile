using UnityEngine;
using System.Collections;

public class TouchRotation : MonoBehaviour {
	public GameObject Objetotarget;
	public Camera MiCamara;
	//Variables para Rotacion ;
	public float rotationVelocity;
	//COMO RIGID BODY
	public Rigidbody rb;

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.touchCount > 0) 
		{        //    If there are touches...
			Touch touch = Input.GetTouch(0);        //    Cache Touch (0)
			
			Ray ray = MiCamara.ScreenPointToRay(touch.position);
			RaycastHit hit;

			
			
			if(Physics.Raycast(ray,out hit,1000))
			{    
				
				
					
					if (touch.phase == TouchPhase.Began) 
					{
						rb.angularVelocity = Vector3.zero; 
						 
					}        
					
					if (touch.phase == TouchPhase.Moved) 
					{

						Objetotarget.transform.Rotate(0, touch.deltaPosition.x * rotationVelocity,0,Space.World);
						rb.AddTorque(0, touch.deltaPosition.x * rotationVelocity,0);

					

					}  
				

					
				
	}
}
	}
}
