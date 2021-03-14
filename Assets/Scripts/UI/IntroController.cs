using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    public MiscControls controls;

    private void Awake()
    {
        controls = new MiscControls();

        controls.Main.AnyKey.performed += AnyKey_performed;
    }

    private void AnyKey_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        StartCoroutine(GameManager.Instance.MainMenuIntroFadeCutscene());
        controls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
