using UnityEngine;

public class LadderInteraction : MonoBehaviour
{

    public PlayerMovement2D player;

    public float speed = 6;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement2D>();
    }

    private void Update()
    {
        if (player.HasAction(ACTION.DESCENDRE_ECHELLE))
        {
            transform.parent.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = true;
            
        }
        else
        {
            transform.parent.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.UpArrow) && player.HasAction(ACTION.MONTER_ECHELLE))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            player.allIconeAction[2].SetActive(true);
            player.allTxtAction[2].SetActive(false);

        }
        else if (other.CompareTag("Player") && Input.GetKey(KeyCode.DownArrow) && player.HasAction(ACTION.DESCENDRE_ECHELLE))
        {
            player.allIconeAction[3].SetActive(true);
            player.allTxtAction[3].SetActive(false);
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        }
        else
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}