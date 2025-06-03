using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerShooterController : MonoBehaviour
{

    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float fireRange = 5f;
    [SerializeField] private Bullet bullet_PreFab;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GameObject spawnLocation;
    [SerializeField] private int dmg = 1;
    private GameObject currentTarget;
    private bool _isShooting;

    private float _timer = 0f;

    public GameObject FindNearestEnemy()
    {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy;

        
        if (enemyList != null)
        {
            if (enemyList.Length > 0)
            {
                nearestEnemy = enemyList[0];
                for (int i = 1; i < enemyList.Length; i++)
                {
                    GameObject y = enemyList[i];
                    if ((nearestEnemy.transform.position - _rb.transform.position).sqrMagnitude > (y.transform.position - _rb.transform.position).sqrMagnitude)
                    {
                        nearestEnemy = y;
                    }
                }
                return nearestEnemy;
                
            }
        }
        return null;           
    }


    public void Shoot()
    {
        GameObject target = FindNearestEnemy();
        _timer += Time.deltaTime;

        

        if (target != null)
        {
            Vector2 target_position = target.transform.position;                       //Prendo la posizione del target
            if (_timer > fireRate)
            {
                if (Vector2.Distance(target_position, _rb.position) < fireRange)
                {

                    _isShooting = true;
                    
                    Bullet _pfBullet = Instantiate(bullet_PreFab);
                    _pfBullet.transform.position = spawnLocation.transform.position;                    
                    Vector2 bullet_position = _pfBullet.transform.position;            //e la sottraggo alla posizione attuale del proiettile
                    Vector2 dir = (target_position - bullet_position);                 //ottengo il nuovo vettore della direzione del proiettile

                              
                

                    float _speed = _pfBullet.GetSpeed();
                    Rigidbody2D _rbBullet = _pfBullet.GetComponent<Rigidbody2D>();
                    _rbBullet.velocity = dir * _speed;

                    _timer = 0f;                    
                }
            }
        }        
    }
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Shoot();        
    }

    private void Update()
    {
        currentTarget = FindNearestEnemy();
        
    }

    public int GetDmg()
    {
        if (dmg <= 0) dmg = 1;
        return dmg;
    }

    public void SetDmg(int dmg)
    {
        this.dmg = dmg;
    }

    public bool IsShooting()
    {
        return _isShooting; 
    }

    public bool StopShooting()
    {
        _isShooting = false;
        return _isShooting;
    }
}
