///-----------------------------------------------------------------
/// Author : Maximilien Galea
/// Date : 09/06/2020 14:45
///-----------------------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace Com.MaxmilienGalea.SummerTime {
	public class Windows : EditorWindow {

		[MenuItem("Tools/Localisation settings")]
		public static void ShowWindow() {
			GetWindow<Windows>("Localisation settings");
		}



	}
}