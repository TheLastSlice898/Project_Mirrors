using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockStim : MonoBehaviour
{

    public bool StageDone;

    // Update is called once per frame
    void Update()
    {
        if (StageDone)
        {
            gameObject.SetActive(true);
        }

        


    }
}
