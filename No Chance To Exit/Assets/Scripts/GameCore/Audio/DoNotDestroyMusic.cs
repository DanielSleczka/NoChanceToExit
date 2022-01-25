using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyMusic : MonoBehaviour
{
    private void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameMusic");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
