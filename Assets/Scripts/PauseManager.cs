using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{

    public bool isPause = false;

    public GameObject panelPause;




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
        }

        if (isPause)
        {
            panelPause.SetActive(true);
        }
        else
        {
            panelPause.SetActive(false);
        }
    }

    public void Resume()
    {
        isPause = false;
        FindObjectOfType<MainMenuManager>().CloseParametre();
    }

    public void Quit()
    {
        // Aller au menu
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1); 
    }



}
