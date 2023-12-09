using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool canOpen = false;
    public GameObject panelEnd;
    PlayerMovement2D player;

    public AudioClip endSong;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement2D>();
    }

    void Update()
    {
      if(Input.GetKeyDown(KeyCode.E) && canOpen && player.HasAction(ACTION.OUVRIR_PORTE))
      {
            panelEnd.GetComponent<Animator>().Play("showJeuMot");
            player.GetComponent<AudioSource>().clip = endSong;
            player.GetComponent<AudioSource>().Play();
            player.allIconeAction[6].SetActive(true);
            player.allTxtAction[6].SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<Animator>().Play("showTextDoor");
            canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<Animator>().Play("eraseText");
            canOpen = false;
        }
    }
}
