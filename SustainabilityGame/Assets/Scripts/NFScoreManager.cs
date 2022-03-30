using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NFScoreManager : MonoBehaviour
{
    public GameObject NfSpoint;
    public GameObject NaCpoint;
    public GameObject NaNpoint;

    public GameObject resultMarker;

    [Range(0, 100)]
    public float NfSscoreStep;
    [Range(0, 100)]
    public float NaCscoreStep;
    [Range(0, 100)]
    public float NaNscoreStep;

    public void MoveToNfS()
    {
        resultMarker.transform.position = Vector3.MoveTowards(resultMarker.transform.position, NfSpoint.transform.position, NfSscoreStep);
    }
    public void MoveToNaC()
    {
        resultMarker.transform.position = Vector3.MoveTowards(resultMarker.transform.position, NaCpoint.transform.position, NaCscoreStep);
    }
    public void MoveToNaN()
    {
        resultMarker.transform.position = Vector3.MoveTowards(resultMarker.transform.position, NaNpoint.transform.position, NaNscoreStep);
    }
}
