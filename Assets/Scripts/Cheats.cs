using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Cheats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            GetComponent<CollisionHandler>().StartLoadingNextLevel();
        }
        if (Input.GetKey(KeyCode.C))
        {
            GetComponent<CollisionHandler>().collisionDisabled = true;
        }
        if(Input.GetKey(KeyCode.Escape)){
            loadMenuScene();
        }
    }

    public void loadMenuScene(){
        SceneManager.LoadScene("Menu");
    }
    
}
