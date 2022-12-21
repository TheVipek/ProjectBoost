using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startDetector : MonoBehaviour
{
    [SerializeField] GameObject UIToActivateAfterClick;
    void Update()
    {
        if(Input.anyKey){
            UIToActivateAfterClick.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
