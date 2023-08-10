using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SHSFDX_QNJYRSETGY
{
	public class ReportData
	{
		public string strHead;
		public DateTime startTime;
		public DateTime endTime;
		public int strTotalScore;
	}
	public class ReportItem : MonoBehaviour
	{
		public TextMeshProUGUI tmpHead;
		public TextMeshProUGUI tmpStartTime;
		public TextMeshProUGUI tmpEndTime;
		public TextMeshProUGUI tmpTotalTime;
		public TextMeshProUGUI tmpTotalScore;
		public ReportData mData;

		public void LoadData(ReportData newData)
		{
			mData = newData;
			tmpHead.text = mData.strHead;
			tmpStartTime.text = mData.startTime.ToString("yyyy-MM-dd HH:mm:ss");
			tmpEndTime.text = mData.endTime.ToString("yyyy-MM-dd HH:mm:ss");
			TimeSpan timeSpan = (mData.endTime - mData.startTime);
			tmpTotalTime.text = $"ʱ����{timeSpan.Hours}ʱ{timeSpan.Minutes}��{timeSpan.Seconds}��";
			tmpTotalScore.text = "�÷֣�" + mData.strTotalScore.ToString();
		}
	}
}

