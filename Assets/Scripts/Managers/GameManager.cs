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

        StartCoroutine(MainMenuIntroCutscene());

        
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

    #region Cutscenes
    public IEnumerator MainMenuIntroCutscene()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(1.5f);

        UIManager.Instance.introController.gameObject.SetActive(true);
        UIManager.Instance.introLogoAnim.Play("Logo Fade In");
        yield return new WaitForSeconds(1.3f);

        UIManager.Instance.introTextAnim.Play("Text Fade In");
        yield return new WaitForSeconds(0.2f);

        UIManager.Instance.introController.controls.Enable();

        PlayMenuMusic();
    }

    public IEnumerator MainMenuIntroFadeCutscene()
    {
        UIManager.Instance.introLogoAnim.Play("Logo Fade Out");
        UIManager.Instance.introTextAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(0.5f);

        UIManager.Instance.introController.gameObject.SetActive(false);
        UIManager.Instance.blackMaskController.FadeToVisible(false);
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
