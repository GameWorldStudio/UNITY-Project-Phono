using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Ce programme permet d'affiché le bon mot au bon coffre et gère le mini-jeu pour trouvé le mot.
/// </summary>
public class ChestInterraction : MonoBehaviour
{
    public GameObject txtInteraction; // Touche d'interraction
    public GameObject panelMot; // Interface pour découvrir le mot
    public int idTextAction; // Id de l'action, correspond a l'indice dans le tableau qui affiche le texte, et l'image de l'action
    public InputField txt; // Zone où l'ont entre le texte


    public PlayerMovement2D playerMovements; // Instance du joueur


    private bool canOpen = false; // Pour savoir si on peux ouvrir le coffre -> Permet entre autre d'afficher le texte (E:Enter) pour indiquer quelle touche appuyer
    [HideInInspector] public bool open = false; // Vérifie si le coffre est ouvert -> Pour évité que le joueur se déplace pendant le mini-jeu

    public ACTION action; // Enum de toute les action possibles

    string motATrouver; // Mot à découvrir (inventé)
    [HideInInspector] public string aide; // L'aide reprend le mot a trouvé mais on lui retire une lettre a chaque fois qu'on se trompe

    string currentAide; // String qui contient les lettres affiché pour aider le joueur

    public AudioClip wrongResponse; // Son du buzzer lorsqu'on se trompe
    public AudioClip felicitation; // Son d'enfant joyeux lorsqu'on trouve le mot

    //Awake est appelé avant le lancement du jeu, il est notamment utiliser pour référencé des variable (pour évité de les remplir à la main) mais ne surtout pas faire d'opération dedans (sinon unity plante)
    void Awake()
    {
        //On regarde la variable d'action référencé et on donne le mot en fonction de celle-ci
        if (action == ACTION.ACCROUPIR)
        {
            motATrouver = "setul";
        }
        else if (action == ACTION.COURIR)
        {
            motATrouver = "netroi";
        }
        else if (action == ACTION.MONTER_ECHELLE)
        {
            motATrouver = "jilo poulen";
        }
        else if (action == ACTION.DESCENDRE_ECHELLE)
        {
            motATrouver = "dajilo poulen";
        }
        else if (action == ACTION.OUVRIR_PORTE)
        {
            motATrouver = "boxa flopu";
        }
        else if (action == ACTION.GAUCHE)
        {
            motATrouver = "golun pluo";
        }
        else if (action == ACTION.DROITE)
        {
            motATrouver = "golun dapluo";
        }
        else if (action == ACTION.SAUTER)
        {
            motATrouver = "matran";
        }

        aide = motATrouver; // Aide est donc egal au mot a trouvé

    }

    //Procédure permettant de jouer le son du monsieur qui dit le mot a voix haute
    public void PlaySound()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("soundVoice") / 100;
        GetComponent<AudioSource>().Play();
    }

    //Update est une procédure qui s'éxécute a chaque frame
    void Update()
    {
        if (canOpen && Input.GetKeyDown(KeyCode.E) && !open) // Si on peux ouvrir, qu'on appuie sur E et que le coffre n'est pas encore ouvert
        {
            aide = motATrouver; // On référencie aide
            GetComponent<Animator>().Play("open"); // On joue l'animation d'ouverture du coffre
            panelMot.GetComponent<Animator>().Play("showJeuMot"); // On joue l'animation d'ouverture du panel
            currentAide = ""; // On reset curret aide
            txt.text = ""; // On efface la zone d'entrer de texte
            open = true; // Le coffre est ouvert
        }

        if (open) // Si c'est ouvert
        {
            FindObjectOfType<ValidateWord>().SetChest(this); // On référencie le coffre courant a un script pont
          //  panelMot.SetActive(true);

        }
    }


    // Procédure qui renvoie un caractère au hasard dans le mot pour aider le joueur
    string GetWord()
    {

        string aideTemp = ""; // Var temporaire

        for (int i = 0; i < aide.Length; i++) // On remplis la variable temporaire
        {
           // if (aide[i] != ' ')
          //  {
                aideTemp += aide[i];
           // }
        }
        int idx = Random.Range(0, aideTemp.Length); // On choisi un index au hasard

        string charRandom;

        //Cette condition permet de ne pas mettre de "-" si cest le dernier caractère (pour faire plus jolie)
        if (aide.Length > 1)
        {
             charRandom = aideTemp[idx] + "-";
        }
        else
        {
            charRandom = aideTemp[idx].ToString();
        }
       
        //Pour généré un espace si le caractère choisi est un espace
        if(charRandom[0] == ' ')
        {
            charRandom = "   " + "-";
        }

        aide = ""; // On reset aide puis on le re-remplis a partir de la variable temporaire sans y mettre l'indice du caractère choisi, ceci aura pour effet d'évité de pioché deux fois le meme

        for (int i = 0; i < aideTemp.Length; i++)
        {
            if (i != idx)
            {
                aide += aideTemp[i];
            }
        }

      
        return charRandom;
    }

    //Cette procédure affiche la lettre pour aidé le joueur
    void ShowLetter()
    {
        Text text = panelMot.transform.GetChild(4).GetComponent<Text>(); // On prend le texte qui affiche les lettres

        if (aide.Length > 0) // Tant qu'il reste des lettres dans le mot
        {
           
            currentAide += GetWord(); // On pioche au hasard

        }

        text.text = "Lettres presentes dans le mot\n" + currentAide; // On affiche
    }

    //Cette procédure gère les interaction entre deux objet (Trigger : le collider de l'objet dois etre sur "trigger" sinon ca serai OnCollisionEnter2D qui gère les collision et non les interaction)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Si l'objet qui entre dans la zone a le tag Player
        {
            canOpen = true; // On peux ouvrir
            GetComponent<Animator>().Play("showText", -1, 0f); // On joue l'animation qui montre le texte pour savoir quelle touche appuyer
            collision.gameObject.GetComponent<PlayerMovement2D>().currentChestInterraction = this; // On lui donne comme coffre courant celui ci
        }
    }

    // Idiem que la procédure du dessus, sauf quelle gère les sortie
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canOpen = false;
            GetComponent<Animator>().Play("eraseText", -1, 0f);
            collision.gameObject.GetComponent<PlayerMovement2D>().currentChestInterraction = null; // On retire le coffre courant
            FindObjectOfType<ValidateWord>().SetChest(null); // Idem
        }
    }

    //Procédure de vérification de réponse
    public void Validate(string reponse)
    {
        if (reponse == motATrouver) // Si le joueur a entré la bonne réponse
        {
            open = false; // On peux pu intergir avec
            canOpen = false;

            GetComponent<Collider2D>().enabled = false; // On désactive son collider
            GameObject.Find("Felicitation").GetComponent<Animator>().Play("felicitation", -1, 0f); // On joue l'animation de félicitation
            panelMot.GetComponent<Animator>().Play("eraseText", -1, 0f); // On efface le texte
            panelMot.transform.GetChild(4).GetComponent<Text>().text = "Lettres presentes dans le mot"; // On reset les lettres
            txt.text = ""; // on reset le zone de texte
          //  panelMot.SetActive(false);
            playerMovements.ShowText(idTextAction); // On affiche le texte du mot représentant l'action
            GetComponent<AudioSource>().volume = (PlayerPrefs.GetFloat("soundVoice") / 100) /2; // On baisse le volume
            GetComponent<AudioSource>().PlayOneShot(felicitation); // On joue le clip de félicitation

            //Add the guessed action to the player
            playerMovements.actions.Add(action); // On a débloquer une nouvelle action
        }
        else
        {
            GetComponent<AudioSource>().volume = (PlayerPrefs.GetFloat("soundVoice") / 100) / 2; // Sinon on joue le buzzer
            GetComponent<AudioSource>().PlayOneShot(wrongResponse); 
            ShowLetter(); // On affiche une lettre pour aider le joueur
        }
    }

    //Si on appuie sur le bouton pour fermer l'interface
    public void Cancel()
    {
        open = false;
        txt.text = "";
        panelMot.transform.GetChild(4).GetComponent<Text>().text = "Lettres presentes dans le mot";
        panelMot.GetComponent<Animator>().Play("eraseText", -1, 0f);
        // panelMot.SetActive(false);

    }
}

public enum ACTION
{
    COURIR,
    SAUTER,
    MONTER_ECHELLE,
    DESCENDRE_ECHELLE,
    GAUCHE,
    DROITE,
    OUVRIR_PORTE,
    ACCROUPIR
}


