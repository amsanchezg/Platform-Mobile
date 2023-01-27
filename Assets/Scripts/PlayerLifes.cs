using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifes : MonoBehaviour
{
    //Vida m�xima y vida actual
    public int maxHealth, currentHealth;
    public float invincibleLength = 1f;
    private float invincibleCounter;
    public GameObject[] lifes;
    [SerializeField] Event charDead;
    GameManager _gameManager;

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //}
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameManager.Singleton;
        currentHealth = maxHealth;
        if (_gameManager.numberlifes.healthText != null)
        {
            _gameManager.numberlifes.healthText.text = currentHealth.ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
        }


    }

    //Para manejar la muerte del jugador
    public void DamagePlayer()
    {
        
        //cuando el jugador tiene invencibilidad, no puede morir
        if (invincibleCounter <= 0)
        {
            
            currentHealth = currentHealth - 1;
            if (currentHealth < 1)
            {

                charDead.Ocurred(this.gameObject);
                currentHealth = 0;
                lifes[2].gameObject.SetActive(false);
                
                
                //gameObject.SetActive(false);
                StartCoroutine(PlayerDie());
                //GameManager.Singleton.Spawn.PlayerDied();
                
            }
            else if (currentHealth < 2)
            {
                GameManager.Singleton.charController.anim.SetTrigger("Hurt");
                GameManager.Singleton.Sounds.Hurt();
                currentHealth = 1;
                lifes[1].gameObject.SetActive(false);
            }
            else if (currentHealth < 3)
            {
                GameManager.Singleton.charController.anim.SetTrigger("Hurt");
                GameManager.Singleton.Sounds.Hurt();
                currentHealth = 2;
                lifes[0].gameObject.SetActive(false);
            }

            //Contador de invencibilidad del jugador
            invincibleCounter = invincibleLength;

            //Actualizar la UI
            
            GameManager.Singleton.numberlifes.healthText.text = currentHealth.ToString();
        }
        
    }

    IEnumerator PlayerDie()
    {
        GameManager.Singleton.damagePlayer.GetComponent<DamagePlayer>().enabled = false;
        GameManager.Singleton.damagePlayer.collider.isTrigger = false;
        GameManager.Singleton.charController.speed = 0;
        GameManager.Singleton.charController.collider.enabled = false;
        GameManager.Singleton.charController.rotationSpeed = 0;
        GameManager.Singleton.Sounds.Die();
        GameManager.Singleton.charController.canJump = false;
        yield return new WaitForSeconds(1f);
        GameManager.Singleton.charController.speed = 0;
        GameManager.Singleton.charController.rotationSpeed = 0;
        yield return new WaitForSeconds(3);
        GameManager.Singleton.Sounds.EndMusic();
        GameManager.Singleton.numberlifes.losePanel.SetActive(true);
        GameManager.Singleton.Sounds.LosingGame();
        
    }
}
