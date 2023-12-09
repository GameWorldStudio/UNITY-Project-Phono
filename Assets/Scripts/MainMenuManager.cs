using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject panelAPropo;
    public GameObject panelParametre;

    public Slider sliderVoice;
    public Text varVoice;

    public Slider sliderMusic;
    public Text varMusic;

    float voiceSound = 50;
    float music = 50;
    private void Start()
    {

        GetComponent<Animator>().Play("debutDeJeu", -1, 0f);

        sliderMusic.value = PlayerPrefs.GetFloat("soundMusic", 50/100);
        sliderVoice.value = PlayerPrefs.GetFloat("soundVoice", 50/100);
        varMusic.text = PlayerPrefs.GetFloat("soundMusic", 50 ).ToString();
        varVoice.text = PlayerPrefs.GetFloat("soundVoice", 50).ToString();

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            GameObject.Find("Player").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("soundMusic") / 100;
        }




    }

    public void LaunchGame()
    {
        GetComponent<Animator>().Play("enterInGame", -1, 0f);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void CloseAPropo()
    {
        panelAPropo.SetActive(false);
    }

    public void OpenAPropo()
    {
        panelAPropo.SetActive(true);
    }

    public void SetVoiceSound()
    {
        voiceSound = sliderVoice.value * 100;
        if(voiceSound > 0)
        {
            varVoice.text = voiceSound.ToString("#");

        }
        else
        {
            varVoice.text = "0";
        }
      

        PlayerPrefs.SetFloat("soundVoice", voiceSound);
    }

    public void SetMusic()
    {
        music = sliderMusic.value * 100;
        if(music > 0)
        {
            varMusic.text = music.ToString("#");
        }
        else
        {
            varMusic.text = "0";
        }

        PlayerPrefs.SetFloat("soundMusic", music);

        try
        {
            GameObject.Find("Player").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("soundMusic") / 100;
        }
        catch(NullReferenceException e)
        {
            GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("soundMusic") / 100;
        }
        
    }

    public void OpenParametre()
    {
        panelParametre.SetActive(true);
    }

    public void CloseParametre()
    {
        panelParametre.SetActive(false);
    }


}
