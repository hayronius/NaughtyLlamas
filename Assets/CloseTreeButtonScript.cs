using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTreeButtonScript : MonoBehaviour
{
    public GameObject DecisionTree;
    public void HideDecisionTree()
    {
        DecisionTree.SetActive(false);
    }
}
