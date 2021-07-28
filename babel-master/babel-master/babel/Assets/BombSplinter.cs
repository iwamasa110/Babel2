using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSplinter : MonoBehaviour
{

    float splinterTime = 1.0f;
    // Update is called once per frame
    void Update()
    {
        //”š’e‚Ì”j•Ğ‚Íw’è‚Ì•b”Œã‚Éíœ
        splinterTime -= Time.deltaTime;
        //”š’e‚Ì”j•ĞˆÚ“®ˆ—
        this.transform.localPosition += transform.forward * 0.05f;

        if (splinterTime < 0)
            Destroy(this.gameObject);
    }
}
