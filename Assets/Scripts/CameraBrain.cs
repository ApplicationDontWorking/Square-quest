using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraBrain : MonoBehaviour
{
    CinemachineBrain cinemachineBrain;

    // Start is called before the first frame update
    void Awake()
    {
        cinemachineBrain = GetComponent<CinemachineBrain>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cinemachineBrain.ActiveBlend != null) Time.timeScale = 0;
        else Time.timeScale = 1;
    }
}
