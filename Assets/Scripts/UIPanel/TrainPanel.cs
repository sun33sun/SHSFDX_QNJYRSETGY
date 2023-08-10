using UnityEngine;
using UnityEngine.UI;
using QFramework;
//using Cysharp.Threading.Tasks;
using UnityEngine.Events;
using Cysharp.Threading.Tasks.Linq;
using DG.Tweening;
using System;
using System.Collections.Generic;

namespace SHSFDX_QNJYRSETGY
{
	public enum TrainState
	{
		Learn, Test
	}
	public enum StudentState
	{
		ID, ASD
	}
	public enum CharacterState
	{
		Mather, Father, Sun, Daughter, FemaleTeacher, MaleTeacher
	}
	public class TrainPanelData : UIPanelData
	{
		public TrainState trainState = TrainState.Learn;
		public StudentState studentState = StudentState.ID;
		public CharacterState characterState = CharacterState.Mather;
	}
	public partial class TrainPanel : UIPanel
	{
		[SerializeField] List<Sprite> characters;
		[SerializeField] List<string> characterNames;

		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as TrainPanelData ?? new TrainPanelData();
			//CheckSelected(btnLearn, () =>
			//{
			//	mData.trainState = TrainState.Learn;
			//	SetTrainTypeSelectButton(false);
			//}).Forget();
			//CheckSelected(btnTest, () =>
			//{
			//	mData.trainState = TrainState.Test;
			//	SetTrainTypeSelectButton(false);
			//}).Forget();
			//CheckSelected(btn_ID, () =>
			//{
			//	mData.studentState = StudentState.ID;
			//	btn_ID.gameObject.SetActive(false);
			//	btn_ASD.gameObject.SetActive(false);
			//}).Forget();
			//CheckSelected(btn_ASD, () =>
			//{
			//	mData.studentState = StudentState.ASD;
			//	btn_ID.gameObject.SetActive(false);
			//	btn_ASD.gameObject.SetActive(false);
			//}).Forget();
			//CheckSelected(ExpandTip,async () =>
			// {
			//	 ExpandTip.transform.DOLocalMoveX(-1060, 0.5f);
			//	 await UniTask.Delay(TimeSpan.FromSeconds(0.6));
			//	 ExpandTip.gameObject.SetActive(false);

			//	 RetractTip.gameObject.SetActive(true);
			//	 RetractTip.transform.DOLocalMoveX(-763, 0.5f);
			//	 await UniTask.Delay(TimeSpan.FromSeconds(0.6));
			// }).Forget();
			//CheckSelected(btnRetractTip,async () =>
			//{
			//	RetractTip.transform.DOLocalMoveX(-1150, 0.5f);
			//	await UniTask.Delay(TimeSpan.FromSeconds(0.6));
			//	RetractTip.gameObject.SetActive(false);

			//	ExpandTip.gameObject.SetActive(true);
			//	ExpandTip.transform.DOLocalMoveX(-863, 0.5f);
			//	await UniTask.Delay(TimeSpan.FromSeconds(0.6));
			//}).Forget();
			//CheckSelected(ExpandStudent,async () =>
			//{
			//	ExpandStudent.transform.DOLocalMoveX(1100, 0.5f);
			//	await UniTask.Delay(TimeSpan.FromSeconds(0.6));
			//	ExpandStudent.gameObject.SetActive(false);

			//	RetractStudent.gameObject.SetActive(true);
			//	RetractStudent.transform.DOLocalMoveX(854, 0.5f);
			//	await UniTask.Delay(TimeSpan.FromSeconds(0.6));
			//}).Forget();
			//CheckSelected(btnRetractStudent,async () =>
			//{
			//	RetractStudent.transform.DOLocalMoveX(1200, 0.5f);
			//	await UniTask.Delay(TimeSpan.FromSeconds(0.6));
			//	RetractStudent.gameObject.SetActive(false);

			//	ExpandStudent.gameObject.SetActive(true);
			//	ExpandStudent.transform.DOLocalMoveX(854, 0.5f);
			//	await UniTask.Delay(TimeSpan.FromSeconds(0.6));
			//}).Forget();
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
			btnLearn.gameObject.SetActive(true);
			btnTest.gameObject.SetActive(true);
			ExpandTip.gameObject.SetActive(true);
			ExpandStudent.gameObject.SetActive(true);

			btn_ID.gameObject.SetActive(false);
			btn_ASD.gameObject.SetActive(false);
			imgTip.gameObject.SetActive(false);
			imgSelectionTitle.gameObject.SetActive(false);
			RetractTip.gameObject.SetActive(false);
			imgDialogue.gameObject.SetActive(false);
			RetractStudent.gameObject.SetActive(false);
			imgShortAnswer.gameObject.SetActive(false);
		}

		//async void Start()
		//{
		//	await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.K));
		//	float timer = Time.realtimeSinceStartup;
		//	await WaitUntilBtnConfirmTipClick("aaaa");
		//	print($"BtnConfirmTipClick : {Time.realtimeSinceStartup - timer}");
		//}

		//async UniTask WaitUntilBtnConfirmTipClick(string content)
		//{
		//	//初始化
		//	imgTip.gameObject.SetActive(true);
		//	tmpTip.text = content;
		//	//出现
		//	imgTip.transform.DOLocalMoveY(0, 0.5f);
		//	imgTip.DOFade(1, 0.5f);
		//	await UniTask.Delay(TimeSpan.FromSeconds(0.6));
		//	//事件
		//	await btnConfirmTip.OnClickAsync();
		//	//消失
		//	imgTip.DOFade(0, 0.5f);
		//	imgTip.transform.DOLocalMoveY(830, 0.5f);
		//	await UniTask.Delay(TimeSpan.FromSeconds(0.6));
		//	//隐藏
		//	imgTip.gameObject.SetActive(false);
		//}

		//async UniTask WaitUntilBtnConfirmDialogueClick(CharacterState newState, string content)
		//{
		//	//初始化
		//	imgDialogue.gameObject.SetActive(true);
		//	mData.characterState = newState;
		//	tmpDialogueContent.text = content;
		//	int characterIndex = (int)newState;
		//	imgCharacter.sprite = characters[characterIndex];
		//	tmpCharacter.text = characterNames[characterIndex];
		//	//出现
		//	imgDialogue.transform.DOLocalMoveY(-385, 0.5f);
		//	imgDialogue.DOFade(1, 0.5f);
		//	await UniTask.Delay(TimeSpan.FromSeconds(0.6));
		//	//事件
		//	await btnConfirmDialogue.OnClickAsync();
		//	//消失
		//	imgDialogue.DOFade(0, 0.5f);
		//	imgDialogue.transform.DOLocalMoveY(-655, 0.5f);
		//	await UniTask.Delay(TimeSpan.FromSeconds(0.6));
		//	//隐藏
		//	imgDialogue.gameObject.SetActive(false);
		//}

		//async UniTask WaitUntilBtnConfirmShortAnswerClick(string content)
		//{
		//	//初始化
		//	imgShortAnswer.gameObject.SetActive(true);
		//	tmpShortAnswerHead.text = content;
		//	//出现
		//	imgShortAnswer.transform.DOLocalMoveY(0, 0.5f);
		//	imgShortAnswer.DOFade(1, 0.5f);
		//	await UniTask.Delay(TimeSpan.FromSeconds(0.6));
		//	//事件
		//	await btnConfirmShortAnswer.OnClickAsync();
		//	//消失
		//	imgShortAnswer.DOFade(0, 0.5f);
		//	imgShortAnswer.transform.DOLocalMoveY(830, 0.5f);
		//	await UniTask.Delay(TimeSpan.FromSeconds(0.6));
		//	//隐藏
		//	imgShortAnswer.gameObject.SetActive(false);
		//}

		//async UniTask WaitUntilBtnConfirmTitleClick()
		//{
		//	//初始化
		//	imgSelectionTitle.gameObject.SetActive(true);
		//	//出现
		//	imgSelectionTitle.DOFade(1, 0.5f);
		//	imgSelectionTitle.transform.DOLocalMoveY(0, 0.5f);
		//	await UniTask.Delay(TimeSpan.FromSeconds(0.6));
		//	//事件
		//	await btnConfirmTitle.OnClickAsync();
		//	//消失
		//	imgSelectionTitle.DOFade(0, 0.5f);
		//	imgSelectionTitle.transform.DOLocalMoveY(900, 0.5f);
		//	await UniTask.Delay(TimeSpan.FromSeconds(0.6));
		//	//隐藏
		//	imgSelectionTitle.gameObject.SetActive(false);
		//}

		protected override void OnHide()
		{
		}

		protected override void OnClose()
		{
		}

		public void SetTrainTypeSelectButton(bool isShow)
		{
			btnLearn.gameObject.SetActive(isShow);
			btnTest.gameObject.SetActive(isShow);
			btn_ID.gameObject.SetActive(!isShow);
			btn_ASD.gameObject.SetActive(!isShow);
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
