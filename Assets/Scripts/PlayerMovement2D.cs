using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{

    public PlayerController controller;

    [SerializeField] public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;
    bool croutch = false;
    bool run = false;
    public Animator animator;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    [HideInInspector] public ChestInterraction currentChestInterraction = null; // Coffre ouvert (quand il y en a un)

    public AudioClip jumpSound;

    //Possible actions
    public List<ACTION> actions;

    public GameObject[] allIconeAction;
    public GameObject[] allTxtAction;

    void Awake()
    {
        actions = new List<ACTION>();
        actions.Add(ACTION.DROITE);
    }
    // Update is called once per frame
    void Update()
    {
        if ((currentChestInterraction == null || !currentChestInterraction.open) && FindObjectOfType<PauseManager>().isPause==false) // On vérifie si un coffre n'est pas ouvert pour évité que le personnage se déplace pendant que l'interface est visible à l'écran
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            allIconeAction[5].SetActive(true);
            animator.SetFloat("Speed", horizontalMove);
            if (Input.GetButtonDown("Jump") && actions.Contains(ACTION.SAUTER))
            {
                jump = true;
                GetComponent<AudioSource>().PlayOneShot(jumpSound);
                allIconeAction[1].SetActive(true);
                allTxtAction[1].SetActive(false);
                animator.SetBool("Jumping", true);
            }

            if (Input.GetButtonDown("Croutch") && actions.Contains(ACTION.ACCROUPIR))
            {
                allIconeAction[7].SetActive(true);
                allTxtAction[7].SetActive(false);
                croutch = true;
            }
            else if (Input.GetButtonUp("Croutch"))
            {
                croutch = false;
            }

            if (Input.GetButtonDown("Run") && actions.Contains(ACTION.COURIR))
            {
                allIconeAction[0].SetActive(true);
                allTxtAction[0].SetActive(false);
                run = true;
            }
            else if (Input.GetButtonUp("Run"))
            {
                run = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (actions.Contains(ACTION.GAUCHE))
        {
            allIconeAction[4].SetActive(true);
        }
        else
        {
            allTxtAction[4].SetActive(false);
        }

        if (horizontalMove * Time.deltaTime < 0 && !actions.Contains(ACTION.GAUCHE))
        {
            controller.Move(0, croutch, run, jump); //Empeche d'aller a gauche si on n'a pas l'action pour
            allIconeAction[4].SetActive(false);
        }
        else
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, croutch, run, jump);
        }
        if (Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position) && !jump)
            animator.SetBool("Jumping", false);
        jump = false;
        animator.SetFloat("Speed", 0);
    }

    public bool HasAction(ACTION _action)
    {
        return actions.Contains(_action);
    }

    public void ShowText(int idx)
    {
        allTxtAction[idx].GetComponent<CanvasGroup>().alpha = 1;
    }


}
