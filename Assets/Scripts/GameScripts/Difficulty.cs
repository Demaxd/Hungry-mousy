using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    [Header("Игрок")]
    [SerializeField]
    [Range(5f, 20f)]
    private float sideSpeed;

    private Animator anim;

    [SerializeField]
    private GameObject mouse;

    [Header("Препятствия")]

    [SerializeField]
    [Range(100f, 200f)]
    private float speedZ;

    [SerializeField]
    [Range(50f, 100f)]
    private float requiredBetween;

    public float SpeedZ { get { return speedZ; } }
    public float RequiredBetween { get { return requiredBetween; } }

    public float SideSpeed { get { return sideSpeed; } }

    private void Start()
    {
        sideSpeed = 5f;
        speedZ = 100f;
        requiredBetween = 100f;
        anim = mouse.GetComponent<Animator>();
        StartCoroutine(IncreaseObstSpeedRoutine());
        StartCoroutine(DecreaseBetweenRoutine());
        StartCoroutine(IncreaseSideSpeedRoutine());
    }


    IEnumerator IncreaseObstSpeedRoutine()
    {
        while (speedZ < 200f)
        {
            speedZ += .5f;
            yield return new WaitForSeconds(1f);
        }
        yield break;
    }
    IEnumerator DecreaseBetweenRoutine()
    {
        while (requiredBetween > 50f)
        {
            requiredBetween -= 0.2f;
            yield return new WaitForSeconds(0.5f);
        }
        yield break;
    }

    private IEnumerator IncreaseSideSpeedRoutine()
    {
        while (sideSpeed < 20f)
        {
            float currentrun = anim.GetFloat("runMultiplier");
            anim.SetFloat("runMultiplier", currentrun + 0.005f);

            float currentjump = anim.GetFloat("jumpMultiplier");
            anim.SetFloat("jumpMultiplier", currentjump + 0.0025f);

            sideSpeed += 0.05f;
            yield return new WaitForSeconds(1f);
        }
        yield break;
    }
}
