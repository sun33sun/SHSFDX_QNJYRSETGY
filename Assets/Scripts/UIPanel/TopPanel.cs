using UnityEngine;
using UnityEngine.UI;
using QFramework;
//using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine.Events;
using Cysharp.Threading.Tasks.Linq;
using DG.Tweening;
using System;

namespace SHSFDX_QNJYRSETGY
{
	public class TopPanelData : UIPanelData
	{
	}
	public partial class TopPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as TopPanelData ?? new TopPanelData();
//			CheckSelected(btnScreen, async () =>
//			 {
//#if UNITY_WEBGL && !UNITY_EDITOR
//				bool newScreenState = !Screen.fullScreen;
//				while (newScreenState != Screen.fullScreen)
//				{
//					Screen.fullScreen = newScreenState;
//					await UniTask.Yield(PlayerLoopTiming.Update);
//				}
//#endif
//			}).Forget();

//			CheckSelected(btnHelp, async () =>
//			{
//				Vector3 newScale = imgHelpBk.transform.localScale;
//				if (newScale.x > 0.5)
//				{
//					while (newScale.x >0)
//					{
//						newScale.x -= Time.deltaTime;
//						newScale.y -= Time.deltaTime;
//						imgHelpBk.transform.localScale = newScale;
//						await UniTask.Yield(PlayerLoopTiming.Update);
//					}
//					imgHelpBk.transform.localScale = new Vector3(0, 0, 1);
//				}
//				else
//				{
//					while (newScale.x <1)
//					{
//						newScale.x += Time.deltaTime;
//						newScale.y += Time.deltaTime;
//						imgHelpBk.transform.localScale = newScale;
//						await UniTask.Yield(PlayerLoopTiming.Update);
//					}
//					imgHelpBk.transform.localScale = Vector3.one;
//				}
				
//			}).Forget();

//			CheckSelected(btnClose, async () =>
//			 {
//				 Vector3 newScale = imgHelpBk.transform.localScale;
//				 while (newScale.x > 0)
//				 {
//					 newScale.x -= Time.deltaTime;
//					 newScale.y -= Time.deltaTime;
//					 imgHelpBk.transform.localScale = newScale;
//					 await UniTask.Yield(PlayerLoopTiming.Update);
//				 }
//				 imgHelpBk.transform.localScale = new Vector3(0, 0, 1);
//			 }).Forget();

//			CheckSelected(btnMain, async () =>
//			{
//				if (!UIKit.GetPanel<CognitionPanel>().gameObject.activeInHierarchy &&
//				!UIKit.GetPanel<TrainPanel>().gameObject.activeInHierarchy &&
//				!UIKit.GetPanel<AnswerPanel>().gameObject.activeInHierarchy &&
//				!UIKit.GetPanel<ReportPanel>().gameObject.activeInHierarchy)
//					return;
//				imgConfirmBackMain.gameObject.SetActive(true);
//				imgConfirmBackMain.DOFade(1, 0.25f);
//				MainPanel mainPanel = UIKit.GetPanel<MainPanel>();
//				await UniTask.WaitUntil(() => mainPanel.gameObject.activeInHierarchy || !imgConfirmBackMain.gameObject.activeInHierarchy);
//			}).Forget();

//			CheckSelected(btnConfirmBackMain, async () =>
//			 {
//				 btnCancelBackMain.interactable = false;
//				 imgConfirmBackMain.DOFade(0, 0.25f);
//				 await UniTask.Delay(TimeSpan.FromSeconds(0.35));
//				 imgConfirmBackMain.gameObject.SetActive(false);
//				 btnCancelBackMain.interactable = true;
//				 #region 获取活动的页面并隐藏它
//				 CognitionPanel cognitionPanel = UIKit.GetPanel<CognitionPanel>();
//				 TrainPanel trainPanel = UIKit.GetPanel<TrainPanel>();
//				 AnswerPanel answerPanel = UIKit.GetPanel<AnswerPanel>();
//				 ReportPanel reportPanel = UIKit.GetPanel<ReportPanel>();

//				 if (cognitionPanel.gameObject.activeInHierarchy)
//					 cognitionPanel.Hide();
//				 else if (trainPanel.gameObject.activeInHierarchy)
//					 trainPanel.Hide();
//				 else if (answerPanel.gameObject.activeInHierarchy)
//					 answerPanel.Hide();
//				 else if (reportPanel.gameObject.activeInHierarchy)
//					 reportPanel.Hide();
//				 #endregion
//				 await UniTask.Delay(TimeSpan.FromSeconds(1));
//				 UIKit.ShowPanel<MainPanel>();
//			 }).Forget();
//			CheckSelected(btnCancelBackMain, async () =>
//			 {
//				 btnConfirmBackMain.interactable = false;
//				 imgConfirmBackMain.DOFade(0, 0.25f);
//				 await UniTask.Delay(TimeSpan.FromSeconds(0.35));
//				 imgConfirmBackMain.gameObject.SetActive(false);
//				 btnConfirmBackMain.interactable = true;
//			 }).Forget();
		}

		//async UniTaskVoid CheckSelected(Button btn, UnityAction invoke)
		//{
		//	var asyncEnumerable = btn.OnClickAsAsyncEnumerable();
		//	var token = this.GetCancellationTokenOnDestroy();
		//	await asyncEnumerable.ForEachAwaitAsync(async _ =>
		//	{
		//		if (token.IsCancellationRequested) return;
		//		AnimatorStateInfo stateInfo = btn.animator.GetCurrentAnimatorStateInfo(0);
		//		while (!stateInfo.IsName("Normal"))
		//		{
		//			stateInfo = btn.animator.GetCurrentAnimatorStateInfo(0);
		//			await UniTask.Yield(PlayerLoopTiming.Update);
		//		}
		//		invoke?.Invoke();
		//	});
		//}

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

		public void SetHead(bool isShow)
		{
			if (isShow)
				imgTopBk.transform.DOLocalMoveY(460.5f, 1);
			else
				imgTopBk.transform.DOLocalMoveY(619.5f, 1);
		}
	}
}
