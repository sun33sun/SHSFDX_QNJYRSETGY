/*
 * JacobKay --20220903
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZTools;
/// <summary>
/// ʹ��ʾ��
/// </summary>
public class ZCalendarDemo : MonoBehaviour
{
    public ZCalendar zCalendar;
    // Start is called before the first frame update
    void Start()
    {
        zCalendar.UpdateDateEvent += ZCalendar_UpdateDateEvent;
        zCalendar.ChoiceDayEvent += ZCalendar_ChoiceDayEvent;
        zCalendar.RangeTimeEvent += ZCalendar_RangeTimeEvent;
        zCalendar.CompleteEvent += ZCalendar_CompleteEvent;
        //zCalendar.Init();
        //zCalendar.Init(System.DateTime.Now);
        //zCalendar.Init("2022-02-02");
        //zCalendar.Show();
        //zCalendar.Hide();
    }
    /// <summary>
    /// ���ؽ���
    /// </summary>
    private void ZCalendar_CompleteEvent()
    {
        Debug.Log("ZCalendar���ؽ���");
        if (null != zCalendar.CrtTime)
        {
            Debug.Log($"��ǰʱ��{zCalendar.CrtTime.Day}");
        }
    }

    /// <summary>
    /// ����ʱ��
    /// </summary>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    private void ZCalendar_RangeTimeEvent(ZCalendarDayItem arg1, ZCalendarDayItem arg2)
    {
        Debug.Log($"ѡ���ʱ�����䣺{arg1.Day}��{arg2.Day}");
    }

    /// <summary>
    /// ��ȡѡ�������
    /// </summary>
    /// <param name="obj"></param>
    private void ZCalendar_ChoiceDayEvent(ZCalendarDayItem obj)
    {
        Debug.Log($"ѡ������ڣ�{obj.Day}");
    }

    /// <summary>
    /// �л��·�ʱ�����õ�ÿһ���item����
    /// </summary>
    /// <param name="obj"></param>
    private void ZCalendar_UpdateDateEvent(ZCalendarDayItem obj)
    {
        Debug.Log($"�������ڣ�{obj.Day}");
    }
    private void OnDestroy()
    {
        zCalendar.UpdateDateEvent -= ZCalendar_UpdateDateEvent;
        zCalendar.ChoiceDayEvent -= ZCalendar_ChoiceDayEvent;
        zCalendar.RangeTimeEvent -= ZCalendar_RangeTimeEvent;
        zCalendar.CompleteEvent -= ZCalendar_CompleteEvent;
    }
}
