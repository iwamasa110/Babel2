using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyerControlloer : MonoBehaviour
{
    
    float BRtime;
    //方向転換のスピード
    public float angleSpeed = 100;
    public float BombReloadTime;
    public float speed;

    public GameObject mainCamera;
    public GameObject BombObj;

    private Vector3 offset;
    private Vector3 setPosition;
    //半径
    private float r = 5;

    //ラジアン
    private float deg = 0;
    float horizontal;
    float vertical;



    // Start is called before the first frame update
    void Start()
    {
        //爆弾の時間制限を保管するために代入
        BRtime = BombReloadTime;

        offset = mainCamera.transform.position - this.transform.position;
        mainCamera.transform.position += offset;
    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Mouse X") * 3f;
        vertical = Input.GetAxis("Mouse Y");


        if (horizontal != 0)
        {
            deg -= horizontal;
        }

        Vector3 playerPos= this.transform.position;

        setPosition.x = playerPos.x + r * Mathf.Cos(Mathf.Deg2Rad * deg);
        setPosition.y = playerPos.y + offset.y;
        setPosition.z = playerPos.z + r * Mathf.Sin(Mathf.Deg2Rad * deg);

        mainCamera.transform.position = setPosition;
        mainCamera.transform.LookAt(this.transform);
        
        //WSキー、↑↓キーで移動する
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        //前進の後退
        //後退は前進の3分の1のスピードになる
        if (z > 0)
        {
            transform.position += transform.forward * z;

        }
        else
        {
            transform.position += transform.forward * z / 3;
        }

        //ADキー、←→キーで方向を替える
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * angleSpeed;
        if(x!=0)
            transform.Rotate(Vector3.up * x);
        else
            transform.rotation = Quaternion.RotateTowards(transform.rotation,mainCamera.transform.GetChild(0).rotation, 0.1f);


        //爆弾発射処理(連続投下出来ないように時間で制御)
        if (Input.GetKeyDown(KeyCode.Space) && BombReloadTime >= BRtime)
        {
            //爆弾生成
            Instantiate(BombObj, this.transform.position + new Vector3(0f, 1.0f, 0f), this.transform.rotation);
            BombReloadTime -= Time.deltaTime;
        }
        else if (BombReloadTime < BRtime && BombReloadTime >= 0) 
        {
            //爆弾投下開始
            BombReloadTime -= Time.deltaTime;
        }
        else if (BombReloadTime < 0)
        {//爆弾の時間制限が過ぎたらリセット
            BombReloadTime = BRtime;
        }

    }


}
