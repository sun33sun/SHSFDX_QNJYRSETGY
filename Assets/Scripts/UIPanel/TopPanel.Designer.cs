using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace SHSFDX_QNJYRSETGY
{
	// Generate Id:a3e6466b-f8da-43e9-b029-c6c74c98d99b
	public partial class TopPanel
	{
		public const string Name = "TopPanel";
		
		[SerializeField]
		public UnityEngine.UI.Image imgTopBk;
		[SerializeField]
		public UnityEngine.UI.Button btnScreen;
		[SerializeField]
		public UnityEngine.UI.Button btnMain;
		[SerializeField]
		public UnityEngine.UI.Button btnHelp;
		[SerializeField]
		public UnityEngine.UI.Image imgHelpBk;
		[SerializeField]
		public UnityEngine.UI.Button btnClose;
		[SerializeField]
		public UnityEngine.UI.Image imgConfirmBackMain;
		[SerializeField]
		public TMPro.TextMeshProUGUI tmpTip;
		[SerializeField]
		public UnityEngine.UI.Button btnConfirmBackMain;
		[SerializeField]
		public UnityEngine.UI.Button btnCancelBackMain;
		
		private TopPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			imgTopBk = null;
			btnScreen = null;
			btnMain = null;
			btnHelp = null;
			imgHelpBk = null;
			btnClose = null;
			imgConfirmBackMain = null;
			tmpTip = null;
			btnConfirmBackMain = null;
			btnCancelBackMain = null;
			
			mData = null;
		}
		
		public TopPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		TopPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new TopPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
