using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public GameObject target;
     public Vector3 offset = new Vector3(-3,2,3);
     public float damping = 1.0f;
     // Use this for initialization
     void Start () {
     
     }
     
     // Update is called once per frame
     void Update () {
        //Mediante el offset y el target, se establece la posicion deseada
         Vector3 desiredPosition = target.transform.position + offset;
         Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
         transform.position = position;
     }
}
