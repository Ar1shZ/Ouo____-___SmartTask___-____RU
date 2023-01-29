using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Do_code : MonoBehaviour
{
    // ���������� ���� �����
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
    // ���������� �������� �����
    void Start()
    {
        HistoryPosition = History.GetComponent<Transform>().position;
        MathPosition = Math.GetComponent<Transform>().position;

        HistoryMoreInfo.SetActive(false);
        MathMoreInfo.SetActive(false);
        RussiaMoreInfo.SetActive(false);
        panel.SetActive(false);
    }
    // ���������� ���������� ����� ���������� ������ �������(������ �������>>����1,����2)
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
    // ������ ��� ��������� �������� ��������� �������� ������(������ ������ "�������" � ���������� �1 �������� 0 � �.�.)
    public void UWUSUB(int a1)
    {
        Info info = gameObject.GetComponent<Info>();
        info.Sub(a1);

        selectSub = a1;
        Debug.Log("������ ��������:" + a1);
    }
    // ������ ��� ��������� �������� �������� ���� ������(������ ������ "������ ������� ����" � ���������� �2 �������� 0 � �.�)
    public void UWUTASK(int a2)
    {
        Info info = gameObject.GetComponent<Info>();
        info.Task(a2);

        selectTask = a2;
        Debug.Log("������ �������:" + a2);
    }
    // �������� �� �� �������� �� ���������� �1 � �2
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

        if (info.allSelect == true && isOnCenter == true)// ���������� isOnCenter ����� ��� ��������� ���� ��� ������������ �� ������� �������� ���� � ����� ����� � ���������
        {
            Debug.Log("���������� ���������:"+info.allSelect +
                ", ������ ��������:" + info.subject +
                ", ������ �������:" +info.task);
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }
    /* ����� ���������� ��������� ���� � ��� ����������
     * ���������� a b c �������� ��������� ������ ������� �� ������������� ��� ������������� ���� ����� ������������ ������ ��
     * � ��������� ��� ������������ ���� ��� � ���� ���������� ���������� ����� ������������ ��� ������� � �������������� sql �� � �� ���� �� ������������) ���� � ��� ���� ����� ���� ����������� �� ��������� ����� �� ������ ��� ��� ��� ��� 18 ������� ������� ������ � � ����� ������ �� ������ �� ���� ����� ��� ������������� ������ ��� ������ �������� ���� ��� �� ��� ���� ����� ������������ ����
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
    // ����� ���������� ����������� ����� ���������
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
    }// �������� �������� � ��� ��� ������� ������ ���������� ����� ��� ������ �� ������ ������ �� ������ �� ���������� a1 � a2 ����� �������� ������� ������ � ��� ��� ��� ������ ��������� � ������ ���
}// ����� ��������� �� ������ ��� ������� �������� � ����� � ��� ��������� ������ 
// �� ������ �������� � ���������� � ������ ����� ��������