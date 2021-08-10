using System;
using System.Collections.Generic;
using UnityEngine;

class TrollKey : Key, Ikey
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            ActiveSwitch(true);
            Destroy(gameObject);
            GameObject tmp = Instantiate(keySound);
            Destroy(tmp, 3);
        }
    }
}