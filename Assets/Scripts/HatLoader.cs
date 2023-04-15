using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatLoader : MonoBehaviour
{
    public GameObject player;
    private void Awake()
    {
        player = HatManager.equippedHat;
    }
}
