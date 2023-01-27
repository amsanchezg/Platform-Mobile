using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoBoton : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip soundClick;
    public AudioClip soundSelect;
    public AudioClip tiquetSound;
    public AudioClip muerteEnemigoSound;
    public AudioClip checkPointSound;
    public AudioClip loseSound;
    public AudioClip jumpSound;
    public AudioClip jumpSound2;
    public AudioClip dash;
    public AudioClip hitSound;
    public AudioClip screamOfDeadSound;
    public AudioClip levelEndSound;
    public AudioClip speedBoost;
    public AudioClip jumpBoost;
    public AudioSource musica;
    public static SonidoBoton sharedinstance;

    private void Awake()
    {
        //Si no hay ninguna instancia en este script
        if (sharedinstance == null)
        {
            //Significa que la instance del UIController va a ser este propio script
            sharedinstance = this;
        }


    }

    public void ClickButton() 
    {
        sound.clip = soundClick;

        sound.enabled = false;
        sound.enabled = true;
    }
    public void SelectButton()
    {
        sound.clip = soundSelect;

        sound.enabled = false;
        sound.enabled = true;
    }

    public void TiquetSound()
    {
        sound.clip = tiquetSound;

        sound.enabled = false;
        sound.enabled = true;
    }

    public void MuerteEnemigoSound()
    {
        sound.clip = muerteEnemigoSound;

        sound.enabled = false;
        sound.enabled = true;
    }

    public void CheckPointSound()
    {
        sound.clip = checkPointSound;

        sound.enabled = false;
        sound.enabled = true;
    }

    public void LoseSound()
    {
        sound.clip = loseSound;

        sound.enabled = false;
        sound.enabled = true;
    }

    public void JumpSound()
    {
        sound.clip = jumpSound;

        sound.enabled = false;
        sound.enabled = true;
    }
    public void JumpSound2()
    {
        sound.clip = jumpSound2;

        sound.enabled = false;
        sound.enabled = true;
    }
    public void DashSound()
    {
        sound.clip = dash;

        sound.enabled = false;
        sound.enabled = true;
    }
    public void HitSound()
    {
        sound.clip = hitSound;

        sound.enabled = false;
        sound.enabled = true;
    }
    public void ScreamOfDeadSound()
    {
        sound.clip = screamOfDeadSound;

        sound.enabled = false;
        sound.enabled = true;
    }
    public void LevelEnd()
    {
        sound.clip = levelEndSound;

        sound.enabled = false;
        sound.enabled = true;
    }
     public void MusicEnd()
    {
        musica.Stop();

        
    }

    public void SpeedBoost()
    {
        sound.clip = speedBoost;

        sound.enabled = false;
        sound.enabled = true;
    }

    public void JumpBoost()
    {
        sound.clip = jumpBoost;

        sound.enabled = false;
        sound.enabled = true;
    }
}
