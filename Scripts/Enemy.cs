using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Enemy : MonoBehaviour
{
    public GameManager GM;
    private Vector3 spwnpos;

    public void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        spwnpos = gameObject.transform.position;
    }

    public void FixedUpdate()
    {
        gameObject.transform.position += Vector3.down * Time.deltaTime * float.Parse(GM.CurDif.ToString());
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GM.playerHP = GM.playerHP - 1;
            GM.COUT();
        }
        Destroy(gameObject);
        GM.Count();
    }
}
