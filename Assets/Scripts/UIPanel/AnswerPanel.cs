using UnityEngine;
using UnityEngine.UI;
using QFramework;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine.Events;
using Cysharp.Threading.Tasks.Linq;

namespace SHSFDX_QNJYRSETGY
{
	public class AnswerPanelData : UIPanelData
	{
	}
	public partial class AnswerPanel : UIPanel
	{
		DateTime startTime;
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as AnswerPanelData ?? new AnswerPanelData();
			CheckBtnSubmit().Forget();
			CheckSelected(btnDoubleConfirm, async () =>
			{
				btnDoubleCancel.interactable = false;
				imgDoubleConfirm.DOFade(0, 0.25f);
				await UniTask.Delay(TimeSpan.FromSeconds(0.6f));
				btnDoubleCancel.interactable = true;
				imgDoubleConfirm.gameObject.SetActive(false);
			}).Forget();
			CheckSelected(btnDoubleCancel, async () =>
			{
				btnDoubleConfirm.interactable = false;
				imgDoubleConfirm.DOFade(0, 0.25f);
				await UniTask.Delay(TimeSpan.FromSeconds(0.6f));
				btnDoubleConfirm.interactable = true;
				imgDoubleConfirm.gameObject.SetActive(false);
			}).Forget();
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
		}
		
		protected override void OnShow()
		{
			startTime = DateTime.Now;
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
		}

		async UniTaskVoid CheckBtnSubmit()
		{
			var asyncEnumerable = btnSubmit.OnClickAsAsyncEnumerable();
			var token = this.GetCancellationTokenOnDestroy();
			int clickCount = 0;
			await asyncEnumerable.ForEachAwaitAsync(async _ =>
			{
				if (token.IsCancellationRequested) return;
				clickCount++;
				AnimatorStateInfo stateInfo = btnSubmit.animator.GetCurrentAnimatorStateInfo(0);
				while (!(stateInfo.IsName("Normal")))
				{
					stateInfo = btnSubmit.animator.GetCurrentAnimatorStateInfo(0);
					await UniTask.Yield(PlayerLoopTiming.Update);
				}
				if (clickCount == 1)
				{
					imgDoubleConfirm.gameObject.SetActive(true);
					imgDoubleConfirm.DOFade(1, 0.25f);
					int btnIndex = await UniTask.WhenAny(btnDoubleConfirm.OnClickAsync(), btnDoubleCancel.OnClickAsync());
					if (btnIndex == 0)
					{
						//Content.Submit();
					}
					else if (btnIndex == 1)
					{
						clickCount = 0;
					}
				}
				else if (clickCount == 2)
				{
					clickCount = 0;
					//生成实验报告
					//ReportData newReportData = new ReportData()
					//{
					//	strHead = "知识答题",
					//	strTotalScore = Content.TotalScore(),
					//	startTime = this.startTime,
					//	endTime = DateTime.Now
					//};
					//UIKit.GetPanel<ReportPanel>().LoadReportData(newReportData);
					Hide();
					await UniTask.WaitUntil(() => !gameObject.activeInHierarchy);
					UIKit.ShowPanel<MainPanel>();
				}
			});
		}

		async UniTaskVoid CheckSelected(Button btn, UnityAction invoke)
		{
			var asyncEnumerable = btn.OnClickAsAsyncEnumerable();
			var token = this.GetCancellationTokenOnDestroy();
			await asyncEnumerable.ForEachAwaitAsync(async _ =>
			{
				if (token.IsCancellationRequested) return;
				AnimatorStateInfo stateInfo = btn.animator.GetCurrentAnimatorStateInfo(0);
				while (!(stateInfo.IsName("Normal")))
				{
					stateInfo = btn.animator.GetCurrentAnimatorStateInfo(0);
					await UniTask.Yield(PlayerLoopTiming.Update);
				}
				invoke?.Invoke();
			});
		}

		public override async void Show()
		{
			base.Show();
			//Content.ResetQuestion();
			objMid.DOLocalMoveY(0, 0.9f);
			await UniTask.Delay(TimeSpan.FromSeconds(1));
		}

		public override async void Hide()
		{
			objMid.DOLocalMoveY(1080, 0.9f);
			await UniTask.Delay(TimeSpan.FromSeconds(1));
			base.Hide();
		}
	}
}
