using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public static CutsceneManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        if (Instance != this) Destroy(gameObject);
    }

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

        GameManager.Instance.PlayMenuMusic();
    }

    public IEnumerator MainMenuIntroFadeCutscene()
    {
        UIManager.Instance.introLogoAnim.Play("Logo Fade Out");
        UIManager.Instance.introTextAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(0.5f);

        UIManager.Instance.introController.gameObject.SetActive(false);
        UIManager.Instance.blackMaskController.FadeToVisible(false);
    }
}
