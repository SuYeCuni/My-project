using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            Enemy hp = other.GetComponent<Enemy>();
            if (hp.hpEnemy > 0)
            {
                other.GetComponent<Enemy>().hpEnemy--;
                if (hp.hpEnemy == 0)
                {
                    Destroy(other.gameObject);
                }
            }
            Destroy(gameObject);
        }
        
    }
    
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("触发结束");
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("碰撞开始");
    }
    
    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("持续碰撞");
    }
    
    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("碰撞结束");
    }
}
