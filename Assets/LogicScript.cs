using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class LogicScript : MonoBehaviour
{
    public VariableReference bar1;
    public BarLogic barLogic;

    // Start is called before the first frame update
    void Start()
    {
        barLogic = GameObject.FindGameObjectWithTag("Bar").GetComponent<BarLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        barLogic.UpdateBar(bar1.Get<int>());
    }
}
