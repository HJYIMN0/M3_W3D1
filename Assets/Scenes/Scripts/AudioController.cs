using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    [SerializeField] private AudioClip Song01;
    [SerializeField] private AudioClip Song02;
    [SerializeField] private AudioSource playingTheme;
    private PlayerShooterController player;
    private AudioClip[] audioClips;
    // Start is called before the first frame update
    void Start()
    {
        
        playingTheme = GetComponent<AudioSource>();
        player = GetComponent<PlayerShooterController>();        
        audioClips = new AudioClip[2];
        audioClips[0] = Song01;
        audioClips[1] = Song02;     
        

        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void Update()
    {

        Debug.Log(player.IsShooting());
        if (player.IsShooting() == true)
        {
            int chooseRandom = UnityEngine.Random.Range(0, 2);
            playingTheme.clip = audioClips[chooseRandom];
            Debug.Log("Play?");
            playingTheme.Play();
            playingTheme.loop = false;
            player.StopShooting();

        }
    }
}
    
        
