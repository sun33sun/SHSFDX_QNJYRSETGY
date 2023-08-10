using UnityEngine;
using UnityEngine.UI;
using QFramework;
using Cysharp.Threading.Tasks;
using System.Threading;
using Cysharp.Threading.Tasks.Linq;
using UnityEngine.Events;
using System;
using DG.Tweening;

namespace SHSFDX_QNJYRSETGY
{
	public class MainPanelData : UIPanelData
	{
	}
	public partial class MainPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as MainPanelData ?? new MainPanelData();


			CheckSelected(btnConfirm, async () =>
			 {
				 objPreview.DOLocalMoveY(1080, 0.9f);
				 await UniTask.Delay(TimeSpan.FromSeconds(1));
				 objPreview.gameObject.SetActive(false);
				 ButtonGroup.gameObject.SetActive(true);
				 UIKit.GetPanel<TopPanel>().SetHead(true);
			 }).Forget();
			CheckSelected(btnCognition, async () =>
			 {
				 SetButtonInteractable(false);
				 ButtonGroup.DOLocalMoveY(1080, 0.9f);
				 await UniTask.Delay(TimeSpan.FromSeconds(1));
				 SetButtonInteractable(true);
				 UIKit.ShowPanel<CognitionPanel>();
				 ButtonGroup.gameObject.SetActive(false);
			 }).Forget();
			CheckSelected(btnTrain, async () =>
			 {
				 SetButtonInteractable(false);
				 Hide();
				 await UniTask.Delay(TimeSpan.FromSeconds(1));
				 SetButtonInteractable(true);
				 UIKit.ShowPanel<TrainPanel>();
			 }).Forget();
			CheckSelected(btnAnswer, async () =>
			 {
				 SetButtonInteractable(false);
				 ButtonGroup.DOLocalMoveY(1080, 0.9f);
				 await UniTask.Delay(TimeSpan.FromSeconds(1));
				 SetButtonInteractable(true);
				 UIKit.ShowPanel<AnswerPanel>();
				 ButtonGroup.gameObject.SetActive(false);
			 }).Forget();
			CheckSelected(btnReport, async () =>
			 {
				 SetButtonInteractable(false);
				 ButtonGroup.DOLocalMoveY(1080, 0.9f);
				 await UniTask.Delay(TimeSpan.FromSeconds(1));
				 SetButtonInteractable(true);
				 UIKit.ShowPanel<ReportPanel>();
				 ButtonGroup.gameObject.SetActive(false);
			 }).Forget();
		}

		void SetButtonInteractable(bool interactable)
		{
			btnCognition.interactable = interactable;
			btnConfirm.interactable = interactable;
			btnReport.interactable = interactable;
			btnTrain.interactable = interactable;
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

		protected override void OnOpen(IUIData uiData = null)
		{
		}
		
		protected override void OnShow()
		{
			ButtonGroup.gameObject.SetActive(true);
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
		}

		public override async void Show()
		{
			base.Show();
			objMid.DOLocalMoveY(0, 0.9f);
			ButtonGroup.DOLocalMoveY(0, 0.9f);
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
