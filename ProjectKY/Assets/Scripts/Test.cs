using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public string myName = "�赵��";
    public int age = 28;
    public float height = 175.3f;
    public bool isGamePlanner = true;
    public string mbti = "INTP";
    public char gender = 'M';

    void Start()
    {
        PrintMyInfo();
    }

    void PrintMyInfo()
    {
        Debug.Log("�̸�: " + myName);
        Debug.Log("����: " + age);
        Debug.Log("Ű: " + height + "cm");
        Debug.Log("���� ��ȹ���ΰ���?: " + isGamePlanner);
        Debug.Log("MBTI: " + mbti);
    }
}
