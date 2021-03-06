using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BllowAway : MonoBehaviour
{
    
    [SerializeField]float impulse = 1000;

    bool isCollision = false;

    Rigidbody rigidBody;
    Rigidbody playerRigidBody;
    GameObject player;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        //プレイヤーをタグで検索し、Rigidbodyを取得
        player = GameObject.FindGameObjectWithTag("splinter");
        playerRigidBody = player.GetComponent<Rigidbody>();
    }

    //衝突判定
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "splinter" && isCollision == false)
        {
            //吹っ飛ばす
            Vector3 playerVelocity = playerRigidBody.velocity;
            rigidBody.AddForce(playerVelocity * impulse, ForceMode.Impulse);
            rigidBody.AddForce(Vector3.up * impulse, ForceMode.Impulse);

            isCollision = true;
        }
    }
}

