using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    float h;
    float v;
    [SerializeField] private int _speed = 5;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();        
    }

    private void Update()
    {
        if (_rb != null)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
        }
        
    }
    
    void FixedUpdate()
    {
        if (_rb != null)
        {
            if (h != 0 || v != 0) 
            {
                Vector2 playerPos = transform.position;
                Vector2 pos = new Vector2(h, v).normalized;
                if (pos != Vector2.zero)
                {
                    _rb.MovePosition(_rb.position + pos * (_speed * Time.fixedDeltaTime));                    
                }
                
            }

        }
        
    }
}
