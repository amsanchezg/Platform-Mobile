using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager 
{
   //Creamos una referencia est�tica que apunta al Singleton
    private static GameManager instance;
    //Singleton
    private PlayerLifes _playerLifes;
    
    //Un accesor a la lista
    public PlayerLifes playerLifes { get { return _playerLifes; } }

    private CameraFollow _cameraFollow;
    public CameraFollow cameraFollow { get { return _cameraFollow; } }

    private Reloj _reloj;
    public Reloj reloj { get { return _reloj; } }

    private CharacterController _charController;

    public CharacterController charController { get { return _charController; } }

    private CoinsManager _coins;

    public CoinsManager coins{ get {return _coins;}}

    private CoinsUI _coinsUI;
    public CoinsUI coinsUI { get { return _coinsUI; } }

    private UI _numberlifes;

    public UI numberlifes { get {return _numberlifes;}}

    private Spawn _spawn;

    public Spawn Spawn { get {return _spawn;}}

    private Sounds _sounds;

    public Sounds Sounds { get { return _sounds; } }

    private DamagePlayer _damagePlayer;

    public DamagePlayer damagePlayer{ get {return _damagePlayer;}}

    private ADSample _ad;
    public ADSample ad { get { return _ad; } }

    //Accesor a la instancia del Singleton
    public static GameManager Singleton
    {
        //El get nos sirve para obtener la informaci�n del Singleton
        get
        {
            //Comprobamos primero que la instancia est� vac�a
            if(instance == null)
            {
                //Rellenamos la referencia del Singleton
                instance = new GameManager();
                instance._playerLifes = GameObject.FindObjectOfType<PlayerLifes>();
                instance._numberlifes = GameObject.FindObjectOfType<UI>();
                instance._coins = GameObject.FindObjectOfType<CoinsManager>();
                instance._coinsUI = GameObject.FindObjectOfType<CoinsUI>();
                instance._spawn = GameObject.FindObjectOfType<Spawn>();
                instance._charController = GameObject.FindObjectOfType<CharacterController>();
                instance._sounds = GameObject.FindObjectOfType<Sounds>();
                instance._damagePlayer = GameObject.FindObjectOfType<DamagePlayer>();
                instance._cameraFollow = GameObject.FindObjectOfType<CameraFollow>();
                instance._reloj = GameObject.FindObjectOfType<Reloj>();
                instance._ad = GameObject.FindObjectOfType<ADSample>();
            }
            
            
                
            //Nos devuelve la informaci�n de la instancia
            return instance;
        }
    }

    public void Nulify()
    {
        instance = null;
        _playerLifes = null;
        _coins = null;
        _coinsUI = null;
        _numberlifes = null;
        _spawn = null;
        _charController = null;
        _sounds = null;
        _damagePlayer = null;
        _reloj = null;
        _ad = null;
    }

    
}
