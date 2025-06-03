using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 dir;
    

    public float GetSpeed()
    {
        return speed;
    }

    public void SetDir(Vector2 dir)
    {
        this.dir = dir;
    }



    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))        {
            
            if (collision != null) 
            {
                GameObject player = GameObject.FindWithTag("Player");
                if (player != null)
                {
                    int dmg = player.GetComponent<PlayerShooterController>().GetDmg();
                    if (dmg > 0)
                    {
                        collision.gameObject.GetComponent<Enemy>().TakeDamage(dmg);
                        if (collision.gameObject.GetComponent<Enemy>().GetHP() <= 0)
                        {
                            Destroy(collision.gameObject);
                        }
                    }
                }
            }
           
        }
        Destroy(gameObject);
        
        
        
    }


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
