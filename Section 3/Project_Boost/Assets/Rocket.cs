using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidbody;
    AudioSource audioSource;
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip explosion;
    [SerializeField] AudioClip win;
    [SerializeField] AudioClip loadLevel;

    [SerializeField] ParticleSystem thrustParticle;
    [SerializeField] ParticleSystem explodeParticle;
    [SerializeField] ParticleSystem winParticle;


    enum State {alive, dead, transition};
    State state = State.alive;
    int currentLevel = 0;

    // Start is called before the first frame update
    void Start()
    {       
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        if (state == State.alive){
            thrustResponse();
            rotateResponse();
        }
    }
    void OnCollisionEnter(Collision collision){

        if (state != State.alive)
            return;

        switch(collision.gameObject.tag){
            case "friendly":
                print("friend!");
                audioSource.PlayOneShot(loadLevel);
                break;

            case "Finish":
                winSequence();
                break;
                
            default:
                deathSequence();
                break;
        }

    }
    private void deathSequence(){
        state = State.dead;
        audioSource.Stop();
        audioSource.PlayOneShot(explosion);
        explodeParticle.Play();
        Invoke("loadNextScene", 2f); //delay
    }
    private void winSequence(){
        state = State.transition;
        this.currentLevel += 1;
        audioSource.Stop();
        audioSource.PlayOneShot(win);
        winParticle.Play();
        Invoke("loadNextScene", 1f); //delay
    }
    private void loadNextScene(){
        SceneManager.LoadScene(this.currentLevel);
    }
    private void rotateResponse(){
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
    private void thrustResponse(){
        if (Input.GetKey(KeyCode.Space)){
             applyThrust();
        }
        else{
            audioSource.Stop();
            thrustParticle.Stop();
        }     
    }
    private void applyThrust(){
        rigidbody.AddRelativeForce(Vector3.up * mainThrust);
            if (!audioSource.isPlaying){ // no layering
                audioSource.PlayOneShot(mainEngine);
                thrustParticle.Play();
            }     
    }
}
