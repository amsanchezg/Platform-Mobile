using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource sound;
    public GameObject music;
    public AudioClip coinSound;
    public AudioClip jumpSound;
    public AudioClip victorySound;
    public AudioClip damage;
    public AudioClip diying;
    public AudioClip loseGame;
    public AudioClip boton;

    public void Mute()
    {
        if (sound.mute)
            sound.mute = false;
        else
            sound.mute = true;
    }
    public void JumpSound()
    {
        sound.clip = jumpSound;

        sound.enabled = false;
        sound.enabled = true;
    }

    public void CoinsSound()
    {
        sound.clip = coinSound;

        sound.enabled = false;
        sound.enabled = true;
    }

    public void Boton()
    {
        sound.clip = boton;

        sound.enabled = false;
        sound.enabled = true;
    }


    public void VictorySound()
    {
        sound.clip = victorySound;
        sound.enabled = false;
        sound.enabled = true;
    }

    public void LosingGame()
    {
        sound.clip = loseGame;
        sound.enabled = false;
        sound.enabled = true;
    }
    public void Hurt()
    {
        sound.clip = damage;
        sound.enabled = false;
        sound.enabled = true;
    }

    public void Die()
    {
        sound.clip = diying;
        sound.enabled = false;
        sound.enabled = true;

    }
    public void EndMusic()
    {
        music.SetActive(false);
        

    }
}
