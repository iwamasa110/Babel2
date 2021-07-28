using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    Rigidbody rb;
    Vector3 keepPos;
    bool set = false,OnJet=false;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!set)
        {
            keepPos = this.transform.position;
            set = true;
        }
        if (OnJet) { 
            keepPos.x = this.transform.position.x;
            keepPos.z = this.transform.position.z;
            this.transform.position = keepPos;
        }
        //キャラクターと床のあたり判定を見て、ないときにはこのスクリプトを実行
        //rb.AddForce(transform.up * 1.5f, ForceMode.Impulse);





    }
    private void OnCollisionEnter(Collision collision)
    {
        //床とのあたり判定がある場合飛行中止
        set = false;
        OnJet = false;
    }

}
