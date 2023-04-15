using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName ="New Hat", menuName ="Create New Hat" )]
public class HatInfo : ScriptableObject
{
    public enum hatsID { hat1, hat2, hat3, hat4, hat5, hat6, hat7, hat8}
    public hatsID TheHatsID;

    public GameObject hatObject;
    public int hatPrice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
