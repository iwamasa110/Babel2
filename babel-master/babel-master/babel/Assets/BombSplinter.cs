using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSplinter : MonoBehaviour
{

    float splinterTime = 1.0f;
    // Update is called once per frame
    void Update()
    {
        //���e�̔j�Ђ͎w��̕b����ɍ폜
        splinterTime -= Time.deltaTime;
        //���e�̔j�Јړ�����
        this.transform.localPosition += transform.forward * 0.05f;

        if (splinterTime < 0)
            Destroy(this.gameObject);
    }
}
