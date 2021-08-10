using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D), typeof(AudioSource))]
public class Player : MonoBehaviour
{
    [Header("Movement")]
    private Rigidbody2D playerBody;
    [SerializeField] float speed;

    [Header("AudioSource")]
    private AudioSource audioSource;
    [SerializeField] GameObject hitSound;
    [SerializeField] float timeToWait;
    private float timeWaited;
    // Start is called before the first frame update
    void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
    }

    void Movement()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (direction.normalized.magnitude != 0)
        {
            playerBody.velocity = direction * speed;

            if(Time.time > timeWaited)
            {
                timeWaited = Time.time + timeToWait;
                audioSource.pitch = 1 + (Random.Range(-0.2f, 0.2f));
                audioSource.Play();
            }
        }
        else playerBody.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.CompareTag("Enemy"))
        {
            Death();
        }

        if (coll.collider.CompareTag("Ganar"))
        {
            SceneManager.LoadScene(1);
        }
    }

    void Death()
    {
        SceneManager.LoadScene(0);
        GameObject tmp = Instantiate(hitSound);
        Destroy(tmp, 3);
        DontDestroyOnLoad(tmp);
    }
}
