using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using ProjectBase;
using QFramework;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SHSFDX_QNJYRSETGY
{
	public class Main : MonoBehaviour
	{
		IEnumerator Start()
		{
			yield return UIKit.OpenPanelAsync<MaskPanel>(UILevel.PopUI, prefabName: Settings.UI + MaskPanel.Name);
			yield return UIKit.PreLoadPanelAsync<MainPanel>(UILevel.Bg, prefabName: Settings.UI + MainPanel.Name);
			yield return UIKit.PreLoadPanelAsync<TopPanel>(UILevel.PopUI, prefabName: Settings.UI + TopPanel.Name);
			yield return UIKit.PreLoadPanelAsync<CognitionPanel>(UILevel.Common, prefabName: Settings.UI + CognitionPanel.Name);
			UIKit.HidePanel<CognitionPanel>();
			yield return UIKit.PreLoadPanelAsync<AnswerPanel>(UILevel.Common, prefabName: Settings.UI + AnswerPanel.Name);
			UIKit.HidePanel<AnswerPanel>();
			yield return UIKit.PreLoadPanelAsync<ReportPanel>(UILevel.Common, prefabName: Settings.UI + ReportPanel.Name);
			UIKit.HidePanel<ReportPanel>();
			yield return UIKit.PreLoadPanelAsync<TrainPanel>(UILevel.Common, prefabName: Settings.UI + TrainPanel.Name);
			UIKit.HidePanel<TrainPanel>();
			UIKit.HidePanel<MaskPanel>();
		}
	}
}

