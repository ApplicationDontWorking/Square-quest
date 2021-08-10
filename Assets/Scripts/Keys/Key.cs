using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Key : MonoBehaviour, Ikey
{
    [Header("Obstacles")]
    [SerializeField] Obstacle obstacle;

    [Header("AudioSource")]
    [SerializeField] protected GameObject keySound;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            ActiveSwitch(false);
            Destroy(gameObject);
            GameObject tmp = Instantiate(keySound);
            Destroy(tmp, 3);
        }
    }

    public virtual void ActiveSwitch(bool index)
    {
        obstacle.gameObject.SetActive(index);
    }
}
