using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyerControlloer : MonoBehaviour
{
    
    float BRtime;
    //�����]���̃X�s�[�h
    public float angleSpeed = 100;
    public float BombReloadTime;
    public float speed;

    public GameObject mainCamera;
    public GameObject BombObj;

    private Vector3 offset;
    private Vector3 setPosition;
    //���a
    private float r = 5;

    //���W�A��
    private float deg = 0;
    float horizontal;
    float vertical;



    // Start is called before the first frame update
    void Start()
    {
        //���e�̎��Ԑ�����ۊǂ��邽�߂ɑ��
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
        
        //WS�L�[�A�����L�[�ňړ�����
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        //�O�i�̌��
        //��ނ͑O�i��3����1�̃X�s�[�h�ɂȂ�
        if (z > 0)
        {
            transform.position += transform.forward * z;

        }
        else
        {
            transform.position += transform.forward * z / 3;
        }

        //AD�L�[�A�����L�[�ŕ�����ւ���
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * angleSpeed;
        if(x!=0)
            transform.Rotate(Vector3.up * x);
        else
            transform.rotation = Quaternion.RotateTowards(transform.rotation,mainCamera.transform.GetChild(0).rotation, 0.1f);


        //���e���ˏ���(�A�������o���Ȃ��悤�Ɏ��ԂŐ���)
        if (Input.GetKeyDown(KeyCode.Space) && BombReloadTime >= BRtime)
        {
            //���e����
            Instantiate(BombObj, this.transform.position + new Vector3(0f, 1.0f, 0f), this.transform.rotation);
            BombReloadTime -= Time.deltaTime;
        }
        else if (BombReloadTime < BRtime && BombReloadTime >= 0) 
        {
            //���e�����J�n
            BombReloadTime -= Time.deltaTime;
        }
        else if (BombReloadTime < 0)
        {//���e�̎��Ԑ������߂����烊�Z�b�g
            BombReloadTime = BRtime;
        }

    }


}
