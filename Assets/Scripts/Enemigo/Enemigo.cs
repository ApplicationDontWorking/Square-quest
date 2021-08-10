using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Enemigo : MonoBehaviour, IEnemigo
{
    Player player;
    [SerializeField] float viewDistance;
    [SerializeField] float moveSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerDistance = player.transform.position - transform.position;
        if(playerDistance.magnitude < viewDistance)
        {
            MoveToPlayer(playerDistance);
        }
    }

    public void MoveToPlayer(Vector2 playerDistance)
    {
        transform.Translate(playerDistance.normalized * moveSpeed * Time.deltaTime);
    }

    public void Active(bool index)
    {
        gameObject.SetActive(index);
    }
}
