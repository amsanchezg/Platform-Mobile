using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CharacterController : MonoBehaviour
{
    private Vector3 PlayerInput;
    //private Vector3 EulerAngle;
    [SerializeField] public float speed;
    [SerializeField] public float rotationSpeed;
    [SerializeField] public float jump;
    [SerializeField] public bool isGrounded;
    [SerializeField] public bool canJump;
    [SerializeField] public Rigidbody rb;
    [SerializeField] public Collider collider;
    [SerializeField] public float playerHeight;
    [SerializeField] public GameObject colliderPersonaje;
    [SerializeField] public GameObject lianaToGet;
    [SerializeField] public bool estaEnLiana;
    [SerializeField] public bool lianaCooldown;

    [SerializeField] public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        //EulerAngle = new Vector3(0,100,0);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 4 + 0.1f);
        
        print(isGrounded);
        Move();
        Liana();

        if (isGrounded)
        {
            anim.SetBool("isGrounded", true);

        }
        else
        {
            anim.SetBool("isGrounded", false);
        }



        
    }

    private void Liana()
    {
        if (estaEnLiana)
        {
            speed = 0;
            rotationSpeed = 0;
            if ((SimpleInput.GetButtonDown("Jump")))
            {
                speed = 6;
                rotationSpeed = 1000;
                Debug.Log("salta puerco");
                anim.SetTrigger("Salto");
                rb.useGravity = true;
                rb.AddForce(transform.forward * 20 * jump * 5);
                StartCoroutine(CooldownLiana());
                estaEnLiana = false;
            }   
        }
    }

    void Move()
    {
        float Horizontal = SimpleInput.GetAxis("Horizontal");
        float Vertical = SimpleInput.GetAxis("Vertical");
        Vector3 PlayerInput = new Vector3(-Vertical, 0f, Horizontal);
        anim.SetFloat("isMoving", new Vector2(Horizontal, Vertical).magnitude);

        PlayerInput.Normalize();
        if (PlayerInput != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(PlayerInput, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        //Quaternion deltaRotation = Quaternion.Euler(EulerAngle * Time.fixedDeltaTime);
        //rb.MoveRotation(rb.rotation * deltaRotation);

        transform.Translate(PlayerInput * speed * Time.deltaTime, Space.World);

        
        
        if ((SimpleInput.GetButton("Jump")) && isGrounded && canJump)
        {
            rb.velocity = Vector3.up * jump;
            isGrounded = false;
            
            anim.Play("Salto"); 
            GameManager.Singleton.Sounds.JumpSound();
        }

        



    }

    public void DamageImpulse()
    {
        
        StartCoroutine(DamagePlayerImpulse());
    }

    public void VictoryDance()
    {
        anim.SetTrigger("Goal");
    }

    public void Die()
    {
        anim.SetTrigger("Diying");
        rb.isKinematic = true;
        collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Liana") && !lianaCooldown)
        {
           
            anim.SetBool("isInRope", true);
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            gameObject.transform.parent = lianaToGet.transform;
            gameObject.transform.position = lianaToGet.transform.position;
            gameObject.transform.rotation = lianaToGet.transform.rotation;
            estaEnLiana = true;
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("isInRope", false);
        rb.constraints = RigidbodyConstraints.None;
        transform.parent = null;
        rb.useGravity = true;
        estaEnLiana = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    IEnumerator CooldownLiana()
    {
        lianaCooldown = true;
        yield return new WaitForSeconds(1.5f);
        lianaCooldown = false;
    }

    IEnumerator DamagePlayerImpulse()
    {
        speed = 0;
        rb.AddForce(-transform.forward * 7 * (5 * 3) * 2);
        rb.velocity = Vector3.up * jump / 2;
        yield return new WaitForSeconds(1f);
        speed = 6;
    }
}
