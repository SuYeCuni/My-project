using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletActive : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletPosition;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bul =  Instantiate(bullet);
            bul.SetActive(true);
            bul.transform.position = bulletPosition.transform.position;
            bul.transform.rotation = bulletPosition.transform.rotation;
            //Debug.Log("生成子弹");
            //Debug.Log(bul.transform.position);
            Destroy(bul,2);
        }
    }
}
