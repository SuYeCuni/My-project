using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttack : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy.hpEnemy > 0)
            {
                other.GetComponent<Enemy>().hpEnemy--;
                if (enemy.hpEnemy == 0)
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
