using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling objectPooling;
    private List<GameObject> enemigoPool;
    [SerializeField] GameObject objectToPool;
    [SerializeField] int objectCount;

    private void Awake()
    {
        objectPooling = this;
        enemigoPool = new List<GameObject>();

    }

    private void Start()
    {
        GameObject tmp;
        for(int i = 0; i < objectCount; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            enemigoPool.Add(tmp);
        }//crea instancias del objeto y luego las desactiva
    }

    #region//getEnemigo
    public GameObject GetEnemigo(Vector3 position)
    {
        for (int i = 0; i < enemigoPool.Count; i++)
        {
            if(!enemigoPool[i].activeInHierarchy)
            {
                enemigoPool[i].SetActive(true);
                enemigoPool[i].transform.position = position;
                return enemigoPool[i];
            }
        }

        //si no hay objetos libres
        GameObject tmp;
        tmp = Instantiate(objectToPool, position, Quaternion.identity);
        enemigoPool.Add(tmp);
        return tmp;
    }
    public GameObject GetEnemigo(Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < enemigoPool.Count; i++)
        {
            if (!enemigoPool[i].activeInHierarchy)
            {
                enemigoPool[i].SetActive(true);
                enemigoPool[i].transform.position = position;
                enemigoPool[i].transform.rotation = rotation;
                return enemigoPool[i];
            }
        }

        //si no hay objetos libres
        GameObject tmp;
        tmp = Instantiate(objectToPool, position, rotation);
        enemigoPool.Add(tmp);
        return tmp;
    }
    #endregion
}
