using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightController : MonoBehaviour
{
    [SerializeField] GameObject highlighter;

    GameObject currentTarget;

    public void Highlight(GameObject target)
    {
        if (currentTarget == target) return;
        currentTarget = target;

        Vector3 pos = target.transform.position;
        Highlight(pos);
    }

    public void Highlight(Vector3 pos)
    {
        highlighter.SetActive(true);
        highlighter.transform.position = pos;
    }

    public void Hide() 
    {
        currentTarget = null;
        highlighter.SetActive(false); }
}
