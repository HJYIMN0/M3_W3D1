using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float maxDistance = 20f;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Vector2 enemyPos;   

    public void EnemyMovement()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerRb = player.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    Vector2 enemyPos = Vector2.MoveTowards(_rb.position, playerRb.position, (speed * Time.fixedDeltaTime));
                    _rb.position = enemyPos;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }

        
    }

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        enemyPos = _rb.position;
        
    }

    private void FixedUpdate()
    {
        EnemyMovement();
    }


}
