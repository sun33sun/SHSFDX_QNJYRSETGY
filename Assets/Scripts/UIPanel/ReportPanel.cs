using UnityEngine;
using UnityEngine.UI;
using QFramework;
using DG.Tweening;
//using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace SHSFDX_QNJYRSETGY
{
	public class ReportPanelData : UIPanelData
	{
	}
	public partial class ReportPanel : UIPanel
	{
		public List<ReportItem> reportItems;
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as ReportPanelData ?? new ReportPanelData();
			// please add init code here
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
		}
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
		}

		public void LoadReportData(ReportData newData)
		{
			reportItems.Find(s => s.gameObject.name == newData.strHead).LoadData(newData);
		}

		public override async void Show()
		{
			base.Show();
			objMid.DOLocalMoveY(0, 0.9f);
			//await UniTask.Delay(TimeSpan.FromSeconds(1));
		}

		public override async void Hide()
		{
			objMid.DOLocalMoveY(1080, 0.9f);
			//await UniTask.Delay(TimeSpan.FromSeconds(1));
			base.Hide();
		}
	}
}
