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
    [SerializeField] public GameObject lianaToGet2;
    [SerializeField] public GameObject lianaToGet3;
    [SerializeField] public bool estaEnLiana;
    [SerializeField] public bool lianaCooldown;
    [SerializeField] bool canMove;
    [SerializeField] public Animator anim;
    [SerializeField] Camera mainCamera;
    [SerializeField] Event liana;

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

    public void Liana()
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
                rb.constraints = RigidbodyConstraints.None;
                rb.useGravity = true;
                rb.AddForce(transform.forward * 20 * jump * 5);
                StartCoroutine(CooldownLiana());
                estaEnLiana = false;
            }   
        }
    }

    void Move()
    {
        if (canMove)
        {
            //Movimiento del jugador
            float Horizontal = SimpleInput.GetAxis("Horizontal");
            float Vertical = SimpleInput.GetAxis("Vertical");
            
            Vector3 cameraForward = Vector3.Scale(mainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 move = Vertical * cameraForward + Horizontal * mainCamera.transform.right;
            anim.SetFloat("isMoving", new Vector2(Horizontal, Vertical).magnitude);

            move.Normalize();
            //Rotacion del personaje
            if (move != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
            //Quaternion deltaRotation = Quaternion.Euler(EulerAngle * Time.fixedDeltaTime);
            //rb.MoveRotation(rb.rotation * deltaRotation);

            transform.Translate(move * speed * Time.deltaTime, Space.World);



            if ((SimpleInput.GetButton("Jump")) && isGrounded && canJump)
            {
                rb.velocity = Vector3.up * jump;
                isGrounded = false;

                anim.Play("Salto");
                GameManager.Singleton.Sounds.JumpSound();
            }
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
        canMove = false;
        collider.enabled = false;
        canJump = false;
        collider.isTrigger = true;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Liana") && !lianaCooldown)
        {
           
            anim.SetBool("isInRope", true);
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            //El jugador se hace hijo del objeto con el que choca, en este caso, la liana
            gameObject.transform.parent = lianaToGet.transform;
            gameObject.transform.position = lianaToGet.transform.position;
            gameObject.transform.rotation = lianaToGet.transform.rotation;
            estaEnLiana = true;
           
        }
        if (other.gameObject.CompareTag("Liana2") && !lianaCooldown)
        {

            anim.SetBool("isInRope", true);
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            //El jugador se hace hijo del objeto con el que choca, en este caso, la liana
            gameObject.transform.parent = lianaToGet2.transform;
            gameObject.transform.position = lianaToGet2.transform.position;
            gameObject.transform.rotation = lianaToGet2.transform.rotation;
            estaEnLiana = true;

        }
        if (other.gameObject.CompareTag("Liana3") && !lianaCooldown)
        {

            anim.SetBool("isInRope", true);
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            //El jugador se hace hijo del objeto con el que choca, en este caso, la liana
            gameObject.transform.parent = lianaToGet3.transform;
            gameObject.transform.position = lianaToGet3.transform.position;
            gameObject.transform.rotation = lianaToGet3.transform.rotation;
            estaEnLiana = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("isInRope", false);
        rb.constraints = RigidbodyConstraints.None;
        //Desparento al jugador de la liana
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
        anim.SetTrigger("Hurt");
        speed = 0;
        rb.AddForce(-transform.forward * 7 * (5 * 3) * 2);
        rb.velocity = Vector3.up * jump / 2;
        yield return new WaitForSeconds(1f);
        speed = 6;
    }
}
