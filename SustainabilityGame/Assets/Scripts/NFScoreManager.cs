using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NFScoreManager : MonoBehaviour
{
    public GameObject NfSpoint;
    public GameObject NaCpoint;
    public GameObject NaNpoint;

    public GameObject resultMarker;

    public void MoveToNfS()
    {
        resultMarker.transform.position = Vector3.MoveTowards(resultMarker.transform.position, NfSpoint.transform.position, 1);
    }
    public void MoveToNaC()
    {
        resultMarker.transform.position = Vector3.MoveTowards(resultMarker.transform.position, NaCpoint.transform.position, 1);
    }
    public void MoveToNaN()
    {
        resultMarker.transform.position = Vector3.MoveTowards(resultMarker.transform.position, NaNpoint.transform.position, 1);
    }
}
