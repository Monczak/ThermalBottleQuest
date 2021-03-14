using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMaskController : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField]
    private Animator anim;
#pragma warning restore CS0649

    public void FadeToBlack(bool right)
    {
        anim.SetTrigger($"ToBlack{(right ? "Right" : "")}");
    }

    public void FadeToVisible(bool right)
    {
        anim.SetTrigger($"ToVisible{(right ? "Right" : "")}");
    }
}