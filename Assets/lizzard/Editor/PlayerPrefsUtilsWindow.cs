using System.Globalization;
using UnityEditor;
using UnityEngine;
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo

namespace lizzard.EditorUtils
{
	public class PlayerPrefsUtilsWindow : EditorWindow {

		private readonly string[] _typeChoices = { "Int", "Float", "String" };
		private int _readTypeChoiceIndex;
		private int _writeTypeChoiceIndex;
		private string _readKey = string.Empty;
		private string _writeKey = string.Empty;

		private string _readResult = string.Empty;
		private string _writeResult = string.Empty;
		private string _writeValue = string.Empty;
		
		[MenuItem("Window/lizzard/PlayerPrefs Utils")]
		private static void Init()
		{
			var window = (PlayerPrefsUtilsWindow)GetWindow(typeof(PlayerPrefsUtilsWindow), false, "PlayerPrefs Utils", true);
			window.Show();
		}

		private void OnGUI()
		{
			GUILayout.Label("Delete all PlayerPrefs", EditorStyles.boldLabel);

			// Delete all
			if (GUILayout.Button("Delete all PlayerPrefs"))
				DeleteAll();
			
			EditorGUILayout.Space();
			
			// Read
			GUILayout.Label("Read from PlayerPrefs", EditorStyles.boldLabel);
			_readKey = EditorGUILayout.TextField("Key: ", _readKey);
			_readTypeChoiceIndex = EditorGUILayout.Popup("Value type: ", _readTypeChoiceIndex, _typeChoices);
			if (GUILayout.Button("Read"))
				ReadPlayerPrefs();
			EditorGUILayout.LabelField("Result: ", _readResult);
			
			EditorGUILayout.Space();
			
			// Write
			GUILayout.Label("Save to PlayerPrefs", EditorStyles.boldLabel);
			_writeKey = EditorGUILayout.TextField("Key: ", _writeKey);
			_writeTypeChoiceIndex = EditorGUILayout.Popup("Value type: ", _writeTypeChoiceIndex, _typeChoices);
			_writeValue = EditorGUILayout.TextField("Value: ", _writeValue);
			if (GUILayout.Button("Save"))
				WriteToPlayerPrefs(_writeValue);
			EditorGUILayout.LabelField("Result: ", _writeResult);
		}

		private void ReadPlayerPrefs()
		{
			if (string.IsNullOrEmpty(_readKey))
			{
				_readResult = "Key is null or empty";
				return;
			}
			
			if(!PlayerPrefs.HasKey(_readKey))
			{
				_readResult = string.Format("No \"{0}\" key found", _readKey);
				return;
			}

			switch (_readTypeChoiceIndex)
			{
				case 0:
					_readResult = PlayerPrefs.GetInt(_readKey).ToString();
					break;
				case 1:
					_readResult = PlayerPrefs.GetFloat(_readKey).ToString(CultureInfo.InvariantCulture);
					break;
				case 2:
					_readResult = PlayerPrefs.GetString(_readKey);
					break;
			}
		}

		private void WriteToPlayerPrefs(string value)
		{
			if (string.IsNullOrEmpty(_readKey))
			{
				_readResult = "Key is null or empty";
				return;
			}

			switch (_writeTypeChoiceIndex)
			{
				case 0:
					int i;
					if (!int.TryParse(value, out i))
					{
						_writeResult = "Cannot cast to int";
						break;
					}
					PlayerPrefs.SetInt(_writeKey, i);
					_writeResult = "Success!";
					break;
				case 1:
					float fl;
					if (!float.TryParse(value, out fl))
					{
						_writeResult = "Cannot cast to float";
						break;
					}
					PlayerPrefs.SetFloat(_writeKey, fl);
					_writeResult = "Success!";
					break;
				case 2:
					PlayerPrefs.SetString(_writeKey, value);
					_writeResult = "Success!";
					break;
			}
		}

		private static void DeleteAll()
		{
			PlayerPrefs.DeleteAll();
			Debug.Log("<b>All PlayePrefs are successfully deleted!</b>");
		}

	}
}

