using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D playerRigidbody;
    public int forceJump;
    public Animator animator;

    public bool isApplyingVoadora;

    public Transform groundCheck;
    public bool grounded;
    public LayerMask whatIsGround;

    public float voadoraTemp;
    public float timeTemp;

    void Start()
    {
        Debug.Log("Hello World!");
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            playerRigidbody.AddForce(new Vector2(0, forceJump));
            isApplyingVoadora = false;
        }

        if (Input.GetButtonDown("Voadora") && grounded)
        {
            isApplyingVoadora = true;
            timeTemp = 0;
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround);


        if (isApplyingVoadora)
        {
            timeTemp += Time.deltaTime;
            if (timeTemp >= voadoraTemp)
            {
                isApplyingVoadora = false;
            }
        }

        animator.SetBool("jump", !grounded);
        animator.SetBool("voadora", isApplyingVoadora);
    }
}
