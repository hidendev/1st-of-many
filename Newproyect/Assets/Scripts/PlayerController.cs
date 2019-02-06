﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject game;
    private Animator animator;
    private AudioSource audioPlayer;

    public AudioClip jumpClip;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool gamePlaying = game.GetComponent<GameController>().gameState == GameState.Playing;
        if(gamePlaying && (Input.GetKeyDown("up")  || Input.GetMouseButtonDown(0))){
            UpdateState("PlayerJump");
        }
    }

    public void UpdateState(string state = null){
        if(state != null){
            animator.Play(state);
        }

    }
      void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Enemy"){
            UpdateState("PlayerDie");
            game.GetComponent<GameController>().gameState = GameState.Ended;
        }
    }
}
