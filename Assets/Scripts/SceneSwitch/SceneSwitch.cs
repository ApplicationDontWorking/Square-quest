using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamrera;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            //virtualCamrera.gameObject.SetActive(true);
            //virtualCamrera.transform.position = transform.position;
            virtualCamrera.Follow = transform;
            virtualCamrera.LookAt = transform;
        }
    }
}
