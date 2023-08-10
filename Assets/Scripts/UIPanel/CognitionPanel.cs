using UnityEngine;
using UnityEngine.UI;
using QFramework;
//using Cysharp.Threading.Tasks;
using UnityEngine.Events;
using System.Threading;
using Cysharp.Threading.Tasks.Linq;
using System;
using DG.Tweening;

namespace SHSFDX_QNJYRSETGY
{
	public class CognitionPanelData : UIPanelData
	{
	}
	public partial class CognitionPanel : UIPanel
	{
		[SerializeField] Color selectedColor;
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as CognitionPanelData ?? new CognitionPanelData();
			string text = tmp_ID.text;
			//CheckToggle(tog_ID,isOn =>
			//{
			//	if (isOn)
			//		tmpInner_ID.color = selectedColor;
			//	else
			//		tmpInner_ID.color = Color.white;
			//	tmp_ID.gameObject.SetActive(isOn);
			//	DOTween.To(() => string.Empty, value => tmp_ID.text = value, text, 3f);
			//}).Forget();
			//string text1 = tmp_ASD.text;
			//CheckToggle(tog_ASD,isOn =>
			//{
			//	if (isOn)
			//		tmpInner_ASD.color = selectedColor;
			//	else
			//		tmpInner_ASD.color = Color.white;
			//	tmp_ASD.gameObject.SetActive(isOn);
			//	DOTween.To(() => string.Empty, value => tmp_ASD.text = value, text1, 3f);
			//}).Forget();
		}

		//async UniTaskVoid CheckToggle(Toggle tog, UnityAction<bool> invoke)
		//{
		//	var ie = tog.OnValueChangedAsAsyncEnumerable();
		//	var token = this.GetCancellationTokenOnDestroy();
		//	Func<bool> func = () => { return tog.animator.GetCurrentAnimatorStateInfo(0).IsName("Normal"); };
		//	await ie.ForEachAwaitAsync<bool>(async isOn =>
		//	{
		//		await UniTask.WaitUntil(func);
		//		invoke(isOn);
		//	}, token);
		//}

		protected override void OnOpen(IUIData uiData = null)
		{
		}

		protected override void OnShow()
		{
			tog_ID.isOn = true;
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
			//await UniTask.Delay(TimeSpan.FromSeconds(1));
		}

		public override async void Hide()
		{
			objMid.DOLocalMoveY(1080, 00.9f);
			//await UniTask.Delay(TimeSpan.FromSeconds(1));
			base.Hide();
		}
	}
}
