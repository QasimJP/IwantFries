using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetChildPos : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0)
            transform.GetChild(0).localPosition = Vector3.zero;
    }
}
