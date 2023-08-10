using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZTools
{
    [RequireComponent(typeof(ZCalendarModel))]
    public class ZCalendar : MonoBehaviour
    {
        /// <summary>
        /// ���ݸ���ʱ���ɻ�ȡ��ÿһ�����ڣ���������в���
        /// </summary>
        public event Action<ZCalendarDayItem> UpdateDateEvent;
        /// <summary>
        /// ���Ի�ȡ�������ĳһ��
        /// </summary>
        public event Action<ZCalendarDayItem> ChoiceDayEvent;
        /// <summary>
        /// ѡ������ʱ���¼�
        /// </summary>
        public event Action<ZCalendarDayItem, ZCalendarDayItem> RangeTimeEvent;
        /// <summary>
        /// �������ؽ���
        /// </summary>
        public event Action CompleteEvent;
        /// <summary>
        /// ��ȡ��ǰѡ�е������
        /// </summary>
        public ZCalendarDayItem CrtTime { get; set; }
        /// <summary>
        /// model
        /// </summary>
        private ZCalendarModel zCalendarModel;
        /// <summary>
        /// controller
        /// </summary>
        private ZCalendarController zCalendarController;
        /// <summary>
        /// ���
        /// </summary>
        private void Start()
        {
            zCalendarModel = this.GetComponent<ZCalendarModel>();
            zCalendarController = new ZCalendarController()
            {
                zCalendar = this,
                zCalendarModel = zCalendarModel,
                pos = this.transform.localPosition
            };
            zCalendarController.Init();
            // ����ʱ�Զ���ʼ��
            if (zCalendarModel.awake2Init)
            {
                Init();
            }
        }
        /// <summary>
        /// ��������ʱ���ʼ��
        /// </summary>
        public void Init()
        {
            zCalendarController.InitDate(DateTime.Now);
        }
        /// <summary>
        /// ����DateTime��ʽ��ʼ������
        /// </summary>
        public void Init(DateTime dateTime)
        {
            zCalendarController.InitDate(dateTime);
        }
        /// <summary>
        /// ����YYYY-MM-DD��ʽ��ʼ������
        /// </summary>
        public void Init(string dateTime)
        {
            string[] dateTimes = dateTime.Split('-');
            zCalendarController.InitDate(new DateTime(int.Parse(dateTimes[0]), int.Parse(dateTimes[1]), int.Parse(dateTimes[2])));
        }
        /// <summary>
        /// ��ʾ����
        /// </summary>
        public void Show()
        {
            zCalendarController.Show();
        }
        /// <summary>
        /// ���ص���
        /// </summary>
        public void Hide()
        {
            zCalendarController.Hide();
        }

        /// <summary>
        /// �л�ʱ��
        /// </summary>
        /// <param name="obj"></param>
        [Obsolete("�¼�����������ʹ��UpdateDateEvent��ȡ�л��·�ʱ���ص�ʱ�����")]
        public void UpdateDate(ZCalendarDayItem obj)
        {
            if (null != UpdateDateEvent)
            {
                UpdateDateEvent.Invoke(obj);
            }
        }
        /// <summary>
        /// ���ڵ��
        /// </summary>
        [Obsolete("�¼�����������ʹ��ChoiceDayEvent��ȡ��ǰѡ���ʱ��")]
        public void DayClick(ZCalendarDayItem dayItem)
        {
            if (null != ChoiceDayEvent)
            {
                ChoiceDayEvent.Invoke(dayItem);
            }
            CrtTime = dayItem;
        }
        /// <summary>
        /// ���ؽ���
        /// </summary>
        [Obsolete("�¼�����������ʹ��CompleteEvent��ȡ������������¼�")]
        public void DateComplete()
        {
            if (null != CompleteEvent)
            {
                CompleteEvent.Invoke();
            }
        }
        /// <summary>
        /// ��������ѡ��
        /// </summary>
        /// <param name="firstDay"></param>
        /// <param name="secondDay"></param>
        [Obsolete("�¼�����������ʹ��RangeTimeEvent��ȡ����ʱ��")]
        public void RangeCalendar(ZCalendarDayItem firstDay, ZCalendarDayItem secondDay )
        {
            if (null != RangeTimeEvent)
            {
                RangeTimeEvent.Invoke(firstDay, secondDay);
            }
        }
        private void OnDestroy()
        {
            zCalendarController = null;
            GC.Collect();
        }
    }
}
