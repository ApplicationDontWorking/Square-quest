using System;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

class SceneSwitchWithEnemys : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamrera;
    [SerializeField] Enemigo enemigo;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            virtualCamrera.Follow = transform;
            virtualCamrera.LookAt = transform;
            enemigo = ObjectPooling.objectPooling.GetEnemigo(transform.position).GetComponent<Enemigo>();
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            enemigo.Active(false);
        }
    }
}