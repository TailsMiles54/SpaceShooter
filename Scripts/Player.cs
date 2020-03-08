using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Player : MonoBehaviour
{
    public float pspd;
    private bool rld = true;
    public GameObject Gamemanager,Bullet;
    public Rigidbody rb;
    void Start()
    {
        pspd = Gamemanager.GetComponent<GameManager>().playerspeed;
        Bullet = Gamemanager.GetComponent<GameManager>().Bullet;
    }

    void Update()
    {
        Shoot();
    }
    
    void FixedUpdate()
    {
        MovementLogic();
    }
    
    private void MovementLogic()
    {
        var direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.Translate(direction * pspd * Time.fixedDeltaTime);
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && rld == true)
        {
            Instantiate(Bullet, gameObject.transform.position + Vector3.up * 1, Quaternion.identity);
            rld = false;
            Invoke("Reload", 1f);
        }
    }

    private void Reload()
    {
        rld = true;
    }
}
