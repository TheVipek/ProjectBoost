using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerReachedChecker : MonoBehaviour
{
    private void OnEnable() {
        int reachedLevel = PlayerPrefs.GetInt("reachedLevel",1);
        
        for (int i = 0; i <= reachedLevel; i++)
        {
            GameObject avaliableLevel =gameObject.transform.GetChild(i).gameObject;
            avaliableLevel.GetComponent<Button>().interactable=true;
        }
    }
}
