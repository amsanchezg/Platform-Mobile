using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatLoader : MonoBehaviour
{
    public GameObject[] allHats;

    private void Start()
    {
        for (int i = 0; i < allHats.Length; i++)
        {
            allHats[i].SetActive(false);
        }
        allHats[HatManager.IDEquipHat].SetActive(true);
    }
}
