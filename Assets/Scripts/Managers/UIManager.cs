using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public BlackMaskController blackMaskController;

    [Header("Main Menu")]
    public GameObject mainMenuCanvas;

    [Header("Intro Objects")]
    public IntroController introController;
    public Animator introLogoAnim;
    public Animator introTextAnim;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        if (Instance != this) Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        FindUIObjects();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FindUIObjects()
    {
        mainMenuCanvas = GameObject.FindGameObjectWithTag("Main Menu");

        introController = GameObject.FindGameObjectWithTag("Intro Canvas").GetComponent<IntroController>();
        introLogoAnim = GameObject.FindGameObjectWithTag("Intro Logo").GetComponent<Animator>();
        introTextAnim = GameObject.FindGameObjectWithTag("Intro Text").GetComponent<Animator>();
    }
}
