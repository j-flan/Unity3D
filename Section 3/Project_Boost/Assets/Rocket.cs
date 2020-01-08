using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        processInput();
    }
    private void processInput(){
        if (Input.GetKey(KeyCode.Space)){
            print("space pressed");
        }
        if (Input.GetKey(KeyCode.A)){
            print("rotate left");
        }
        else if (Input.GetKey(KeyCode.D)){
            print("rotate right");
        }
    }
}
