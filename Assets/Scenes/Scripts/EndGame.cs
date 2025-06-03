using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    GameObject player;
    public Text error;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            error.text = "Error 404:\r\nCharacter not found!!!";
            error.gameObject.SetActive(true);
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
