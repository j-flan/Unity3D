using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidbody;
    AudioSource audioSource;
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        thrust();
        rotate();
    }
    void OnCollisionEnter(Collision collision){
        switch(collision.gameObject.tag){
            case "friendly":
                print("thats fine...");
                break;
            case "dead":
                print("dead");
                break;
        }

    }
    private void rotate(){
        
        rigidbody.freezeRotation = true; // manual control
        float rotationFrame = rcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.A)){
            
            transform.Rotate(Vector3.forward * rotationFrame);
        }
        else if (Input.GetKey(KeyCode.D)){
            transform.Rotate(-Vector3.forward * rotationFrame);
        }
        rigidbody.freezeRotation = false; //relase user physics
    }
    private void thrust(){
        if (Input.GetKey(KeyCode.Space)){
            rigidbody.AddRelativeForce(Vector3.up * mainThrust);
            if (!audioSource.isPlaying){ // no layering
                audioSource.Play();
            }      
        }
        else{
            audioSource.Stop();
        }
    }
}
