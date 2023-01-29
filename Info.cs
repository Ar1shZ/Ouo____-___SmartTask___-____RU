using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
    public int subject = 0;
    public int task = 0;

    public int otherSub = 0;
    public int otherTask = 0;
    // Вот это всё надо для передачи инофрмации между скриптами

    public void Sub(int Sub)
    {
        subject = Sub;
    }

    public void Task(int Task)
    {
        task = Task; 
    }
    public bool allSelect;

    void Update()
    {
        otherSub = gameObject.GetComponent<Do_code>().selectSub;
        if (subject != otherSub)
        {
            subject = otherSub;
        }

        otherTask = gameObject.GetComponent<Do_code>().selectTask;
        if (subject != otherTask)
        {
            task = otherTask;
        }
    }
}
