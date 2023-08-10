using UnityEngine;
using UnityEngine.UI;
using QFramework;
using DG.Tweening;
//using Cysharp.Threading.Tasks;
using System;

namespace SHSFDX_QNJYRSETGY
{
	public class MaskPanelData : UIPanelData
	{
	}
	public partial class MaskPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as MaskPanelData ?? new MaskPanelData();
			TyperAnim();
		}

		bool canHide = false;

		async void TyperAnim()
		{
			string text = tmpContent_ID.text;
			DOTween.To(() => string.Empty, value => tmpContent_ID.text = value, text, 5);
			//await UniTask.Delay(TimeSpan.FromSeconds(5));
			text = tmpContent_ASD.text;
			tmpContent_ASD.gameObject.SetActive(true);
			DOTween.To(() => string.Empty, value => tmpContent_ASD.text = value, text, 5);
			//await UniTask.Delay(TimeSpan.FromSeconds(6));
			canHide = true;
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


		public override async void Hide()
		{
			//await UniTask.WaitUntil(() => canHide);
			base.Hide();
		}
	}
}
