using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Do_code : MonoBehaviour
{

    // declaration of all fields
    public Text code; 

    public Button History;
    public Button Math;
    public Button Russia;

    public Vector3 SelectPosition = new Vector3(0, 0, 0);
    public Vector3 HistoryPosition;
    public Vector3 MathPosition;
    public Vector3 RussiaPosition;

    public bool anotherSelect = false;
    public bool isOnCenter  = false;
    public int whatIndexSub;

    public GameObject HistoryMoreInfo;
    public GameObject MathMoreInfo;
    public GameObject RussiaMoreInfo;
    public GameObject panel;

    public int selectSub = 0;
    public int selectTask = 0;

    public Camera firstScreen;
    public Camera secondScreen;
    // assigning field values
    void Start()
    {
        HistoryPosition = History.GetComponent<Transform>().position;
        MathPosition = Math.GetComponent<Transform>().position;

        HistoryMoreInfo.SetActive(false);
        MathMoreInfo.SetActive(false);
        RussiaMoreInfo.SetActive(false);
        panel.SetActive(false);
    }
    // implementation of the disclosure of a more detailed list of tasks (example History>>Thema1,Thema2)
    public void On_Lesson_History()
    {
        if (anotherSelect == false || whatIndexSub == 0)
        {
            if (isOnCenter ==  false)
            {
                whatIndexSub = 1;
                anotherSelect = true;
                HistoryMoreInfo.SetActive(true);
                History.gameObject.transform.transform.localPosition = SelectPosition;
                isOnCenter = true;
                anotherSelect = false;
            }
            else
            {
                if (isOnCenter == true)
                {
                    anotherSelect = true;
                    HistoryMoreInfo.SetActive(false);
                    History.gameObject.transform.transform.position = HistoryPosition;
                    isOnCenter = false;
                    anotherSelect = false;
                    whatIndexSub = 0;
                }
            }
        }
        
    }

    public void On_Lesson_Math()
    {
        if (anotherSelect == false || whatIndexSub == 0)
        {
            if (isOnCenter == false)
            {
                anotherSelect = true;
                MathMoreInfo.SetActive(true);
                Math.gameObject.transform.transform.localPosition = SelectPosition;
                isOnCenter = true;
                anotherSelect = false;
                whatIndexSub = 2;
            }
            else
            {
                if (isOnCenter == true)
                {
                    anotherSelect = true;
                    MathMoreInfo.SetActive(false);
                    Math.gameObject.transform.transform.position = MathPosition;
                    isOnCenter = false;
                    anotherSelect = false;
                    whatIndexSub = 0;
                }
            }
        }
    }

    public void On_Lesson_Russia()
    {
        if (anotherSelect == false || whatIndexSub == 0)
        {
            if (isOnCenter == false)
            {
                whatIndexSub = 3;
                anotherSelect = true;
                RussiaMoreInfo.SetActive(true);
                Russia.gameObject.transform.transform.localPosition = SelectPosition;
                isOnCenter = true;
                anotherSelect = false;
            }
            if(isOnCenter == true)
            {
                anotherSelect = true;
                RussiaMoreInfo.SetActive(false);
                Russia.gameObject.transform.transform.position = RussiaPosition;
                isOnCenter = false;
                anotherSelect = false;
                whatIndexSub = 0;
            }
        }
    }
    // methods for obtaining the value of the discarded object example (the "History" button is pressed in the variable a1 value 0, etc.)
    public void UWUSUB(int a1)
    {
        Info info = gameObject.GetComponent<Info>();
        info.Sub(a1);

        selectSub = a1;
        Debug.Log("Индекс предмета:" + a1);
    }
    // methods for obtaining the value of the selected topic example (the button "Kneyazi Ancient Rus" is pressed in the variable a2 value 0, etc.)
    public void UWUTASK(int a2)
    {
        Info info = gameObject.GetComponent<Info>();
        info.Task(a2);

        selectTask = a2;
        Debug.Log("Индекс задания:" + a2);
    }
    // checking whether variables a1 and a2 are filled in
    void Update()
    {
        Info info = gameObject.GetComponent<Info>();
        if (selectTask != 0 || selectSub != 0)
        {
            info.allSelect = true;
        }
        else
        {
            info.allSelect = false;
        }
        if (info.task > 0 && info.subject > 0)
        {
            info.allSelect = true;
        }
        else
        {
            info.allSelect = false;
        }

        if (info.allSelect == true && isOnCenter == true)// the isOnCenter variable is needed to make sure that the user has not accidentally collapsed the menu and is exactly ready for generation
        {
            Debug.Log("Готовность генерацие:"+info.allSelect +
                ", Индекс предмета:" + info.subject +
                ", Индекс задания:" +info.task);
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }
    /* This is where the code is generated and encrypted
  * variables a b c key the rest are random, which is not used for decryption, it will be necessary to use them
 * unfortunately, this is the only way I can transfer information between devices there was an option with using sql, but I don't know how to use it) if you have any suggestions, please immediately send them to me since it's already 18 February trial protection and I almost did not do anything from the whole mass that was planned, only this poor code transfer is not there, well, at least there is a user layout
  */
    public void MakeCode()
    {
        Info info = gameObject.GetComponent<Info>();
        int g = Random.Range(3, 8);
        int f = Random.Range(1, 9);
        int e = Random.Range(1, 9);

        int a = Random.Range(1, 3);

        int b = gameObject.GetComponent<Do_code>().selectSub + a;
        int c = gameObject.GetComponent<Do_code>().selectTask - 1;

        string d = f.ToString() + a.ToString() + b.ToString() + g.ToString() + c.ToString() + e.ToString();
        code.text = d;

        Debug.Log(code.text);
    }
    // this is where the movement between screens takes place

    public void RHRH(int a)
    {
        Info info = gameObject.GetComponent<Info>();
        if (a == 1)
        {
            firstScreen.gameObject.SetActive(true);
            secondScreen.gameObject.SetActive(false);
            selectSub = 0;
            selectTask = 0;
            info.allSelect = false;
        }

        if (a == 2)
        {
            firstScreen.gameObject.SetActive(false);
            secondScreen.gameObject.SetActive(true);
        }
    }// the main problem is that the buttons are pressed through the race, that is, you can press the button, but the variable a1 and a2 may remain the same the joke is that it sometimes works and sometimes not
}// I would also like to know how to make a gradient in unity and how to round the buttons
 // for questions and wishes, I am always ready to answer