using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState gameState;

    public Camera mainCamera;

    public LayeredBGM menuMusic;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        if (Instance != this) Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        BeginMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Scene Load Events
    public void OnSceneLoaded()
    {
        mainCamera = Camera.main;
    }

    public void OnMenuLoaded()
    {
        gameState = GameState.MainMenu;

        LayeredBGMPlayer.Instance.Stop();
        LayeredBGMPlayer.Instance.UnloadBGM();

        PlayMenuMusic();
    }

    public void OnGameLoaded()
    {

    }
    #endregion

    #region Control Flow
    void BeginMenu()
    {

    }
    #endregion

    #region Music
    void PlayMenuMusic()
    {
        LayeredBGMPlayer.Instance.currentBGM = menuMusic;
        LayeredBGMPlayer.Instance.LoadBGM();
        LayeredBGMPlayer.Instance.Play();
    }
    #endregion
}
