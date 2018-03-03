using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public FloatVariable score;
    public FloatVariable killsCounter;

    public void AddKill()
    {
        killsCounter.Add(1);
    }

    public void AddPointsToScore(float points)
    {
        score.Add(points);
    }

//#if UNITY_EDITOR
//    [Header("Debug")]
//    public float repeatEverySeconds;
//    private void Update()
//    {
//        StartCoroutine(Encapsulator());
//    }

//    private IEnumerator Encapsulator()
//    {
//        AddKill();
//        AddPointsToScore(100);
//        yield return new WaitForSeconds(repeatEverySeconds);
//    }
//#endif
}
