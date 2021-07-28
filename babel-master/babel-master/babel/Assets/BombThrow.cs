using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombThrow : MonoBehaviour
{
    Rigidbody rg;
    GameObject playerObj;
    float set=0,bombTimer=3.0f;
    Vector3 keepPlayer;
    void Start()
    {
        rg = this.GetComponent<Rigidbody>();
        playerObj=GameObject.Find("Player");
        keepPlayer = this.transform.position;
    }

    void Update()
    {
        float posY = this.transform.position.y;
        float playerY = playerObj.transform.position.y;

        if (set == 0)
        {
            //プレイヤーの高さ＋指定の数値を越えるまで斜め移動
            this.transform.position += 0.1f * transform.forward;
            this.transform.position += 0.4f * transform.up;
            if (posY < playerY + 5.0f)
                set++;
        }
        else if (set == 1)
        {
            this.transform.position += 0.05f * transform.forward;
            if (posY < playerY-0.8f)
                set++;
        }
        else if (set == 2) 
        {
            bombTimer -= Time.deltaTime;
            rg.velocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
            if (bombTimer <= 0) { 
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(2).gameObject.SetActive(true);
                transform.GetChild(3).gameObject.SetActive(true);
            }
        }
    }
}
