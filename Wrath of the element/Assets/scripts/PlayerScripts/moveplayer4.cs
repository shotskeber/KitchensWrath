using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveplayer4 : MonoBehaviour {
	//Public variables
	public float pos = 0.2f;
	public float jumpPower;
	public float dashForce = 3f;
	public float hitForce = 0f;
	public float moveDisable = 1;
	public bool burning = false;
	public GameObject dashHitP;
	public GameObject runFX;
	public GameObject fireFx;

	public Vector2 velocity;
	public Rigidbody2D rb2D;


    public bool isDashing = false;
	public bool isGrounded = false;
    private bool fireon = false;


	//Private Variables
	private float timerDash = 0f;
	private float charDirection = 1;
	private float dashCooldown = 0f;

	public float dashTimedOut = 0.2f;

    private Animator[] animators;
    private Animator animClass;
    

    void Start()
    {
        animators = gameObject.GetComponentsInChildren<Animator>();

        foreach (Animator anim in animators)
        {
            if (anim.gameObject.transform.parent != null)
            {
                animClass = anim; //this gameObject is a child, because its transform.parent is not null
            }
        }
    }


    void Update()

	{

		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		if (burning == true) {
			rb.velocity = new Vector2 (pos * 10 * moveDisable * charDirection * 1.5f, rb.velocity.y);
			if (inputManager.Move_p4 () > 0) {
				charDirection = 1;
				rb.transform.localScale = new Vector3 (-Mathf.Abs (rb.transform.localScale.x), rb.transform.localScale.y, rb.transform.localScale.z);
			} else if (inputManager.Move_p4 () < 0) {
				charDirection = -1;
				rb.transform.localScale = new Vector3 (Mathf.Abs (rb.transform.localScale.x), rb.transform.localScale.y, rb.transform.localScale.z);
			}
		} else {
			if (inputManager.Move_p4 () > 0) {
				rb.velocity = new Vector2 (pos * 10 * moveDisable, rb.velocity.y);
				charDirection = 1;
				rb.transform.localScale = new Vector3 (-Mathf.Abs (rb.transform.localScale.x), rb.transform.localScale.y, rb.transform.localScale.z);
			} else if (inputManager.Move_p4 () < 0) {
				rb.velocity = new Vector2 (-pos * 10 * moveDisable, rb.velocity.y);
				charDirection = -1;
				rb.transform.localScale = new Vector3 (Mathf.Abs (rb.transform.localScale.x), rb.transform.localScale.y, rb.transform.localScale.z);
			}
		}
        if (rb.velocity.x > 0 && isGrounded)
        {
            animClass.SetInteger("State", 1);
        }
        if (rb.velocity.x < 0 && isGrounded)
        {
            animClass.SetInteger("State", 1);
        }
        if (rb.velocity.x == 0)
        {
            animClass.SetInteger("State", 0);
        }
        if (burning) {
            fireFx.GetComponent<ParticleSystem>().Play();
            runFX.GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
            if (gameObject.GetComponent<Transform>().Find("oil_fx(Clone)"))
            {
                gameObject.GetComponent<Transform>().Find("oil_fx(Clone)").GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
            }
        } else {
            fireFx.GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);

            if (gameObject.GetComponent<Rigidbody2D>().sharedMaterial == null)
            {
                if (gameObject.GetComponent<Transform>().Find("oil_fx(Clone)"))
                {
                    Destroy(gameObject.GetComponent<Transform>().Find("oil_fx(Clone)").gameObject);
                }
                if (inputManager.Move_p4() != 0)
                {
                    if (isGrounded)
                    {
                        runFX.GetComponent<ParticleSystem>().Play();
                    }
                    else
                    {
                        runFX.GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
                    }
                }
                else
                {
                    runFX.GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
                }
            }
            else
            {
                gameObject.GetComponent<Transform>().Find("oil_fx(Clone)").GetComponent<ParticleSystem>().Play();
                runFX.GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
            }
        }

		if (inputManager.Jump_p4())
		{
			if (isGrounded)
			{
                animClass.SetInteger("State", 3);
                if (GameObject.FindGameObjectWithTag ("wind") == null) {
					rb.AddForce (Vector2.up * (jumpPower * 1000));
				} else {
					rb.AddForce (Vector2.down * (jumpPower * 1000));
				}
			}
		}

		if (inputManager.Dash_p4()) {
			if (dashCooldown <= 0) {
				isDashing = true;
            }
		}


		if (dashCooldown > 0) {
			dashCooldown -= Time.deltaTime;
		}

		if (isDashing) {
			if (timerDash < 0.25) {
                animClass.SetInteger("State", 2);
                rb.velocity = new Vector2 (30f*charDirection, 0f);
				timerDash += Time.deltaTime;
				dashCooldown = dashTimedOut;
				moveDisable = 0;

			} else { 
				isDashing = false;
				timerDash = 0f;
				rb.velocity = new Vector2 (15f*charDirection, 0f);
				moveDisable = 1;
			}
		}  else {
			moveDisable = 1;
		}


	}

    public void burnOver(){
		Invoke("returnNormal",5);
	}
	void returnNormal(){
        if (burning == true)
        {
            burning = false;
        }
	}


	void OnCollisionEnter2D(Collision2D coll) {
		Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (coll.gameObject.CompareTag ("Player")) {
			if(isDashing){
                animClass.SetTrigger("Dashhit");
                GameObject.Find ("hitSoundManager").GetComponent<hitSound> ().PlaySound ();
				GameObject clone = Instantiate (dashHitP, gameObject.transform.position, Quaternion.identity);
				clone.transform.parent = gameObject.transform;
				Destroy (clone, 0.1f);
				isDashing = false;
				timerDash = 0f;
				rb.velocity = new Vector2 (0f, 0f);
				if (!coll.gameObject.GetComponent<push> ().isPushed) {
					coll.gameObject.GetComponent<push> ().pushChar (charDirection, hitForce);
				}
				if (coll.gameObject.GetComponent<SaltPlayer> ().HoldSalt) {
                    coll.gameObject.GetComponent<SaltPlayer> ().HoldSalt = false;
					gameObject.GetComponent<SaltPlayer> ().HoldSalt = true;
				}
			}
		}
		if (coll.gameObject.CompareTag ("floor")|| coll.gameObject.CompareTag("fire")) {
			if(GameObject.FindGameObjectWithTag("wind") != null){
				if (coll.gameObject.transform.position.y > gameObject.transform.position.y) {
					isGrounded = true;
				} else {
					isGrounded = false;
				}
			}else{
				if (coll.gameObject.transform.position.y < gameObject.transform.position.y) {
					isGrounded = true;
				} else {
					isGrounded = false;
				}
			}
		}
		if (coll.gameObject.CompareTag ("wokplatform")) {
			isGrounded = true;
		}

	}

	void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.CompareTag ("floor")) {
			isGrounded = false;
		}
		if (coll.gameObject.CompareTag ("wokplatform")) {
			isGrounded = false;
		}
	}
}
