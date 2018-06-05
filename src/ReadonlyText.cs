using System.Collections.Generic;
using System.Linq;
using Litium.FieldFramework;
using Litium.FieldFramework.Converters;
using Litium.FieldFramework.FieldTypes;
using Litium.Runtime.DependencyInjection;
using Litium.Web.Administration;
using Litium.Web.Administration.FieldFramework;
using Newtonsoft.Json.Linq;

namespace Litium.Accelerator.FieldFramework
{
	internal class ReadonlyTextAdministrationExtension : IAppExtension
	{
		public IEnumerable<string> ScriptFiles { get; } = null;
		public IEnumerable<string> AngularModules { get; } = null;
		public IEnumerable<string> StylesheetFiles { get; } = null;
	}

	[Service(Name = "ReadonlyText")]
	internal class ReadonlyTextEditFieldTypeConverter : IEditFieldTypeConverter
	{
		public object ConvertFromEditValue(EditFieldTypeConverterArgs args, JToken item)
		{
			return new { };
		}

		public JToken ConvertToEditValue(EditFieldTypeConverterArgs args, object item)
		{
			return new JObject();
		}

		public object CreateOptionsModel()
		{
			return new TextOption();
		}

		public string EditControllerName { get; } = "";
		public string EditControllerTemplate { get; } = "";
		public string SettingsControllerName { get; } = null;
		public string SettingsControllerTemplate { get; } = null;
		public string EditComponentName => "Accelerator#FieldEditorReadonlyText";
		public string SettingsComponentName => null;
	}

	[Service(Name = "ReadonlyText")]
	internal class ReadonlyTextJsonFieldTypeConverter : IJsonFieldTypeConverter
	{
		public object ConvertFromJsonValue(JsonFieldTypeConverterArgs args, JToken item)
		{
			return new { };
		}

		public JToken ConvertToJsonValue(JsonFieldTypeConverterArgs args, object item)
		{
			return new JObject();
		}
	}

	public class ReadonlyTextFieldTypeMetadata : FieldTypeMetadataBase
	{
		public override string Id => "ReadonlyText";
		public override bool IsArray => false;

		public override IFieldType CreateInstance(IFieldDefinition fieldDefinition)
		{
			var item = new ReadonlyTextFieldType();
			item.Init(fieldDefinition);
			return item;
		}

		public class ReadonlyTextFieldType : FieldTypeBase
		{
			public override object GetValue(ICollection<FieldData> fieldDatas)
			{
				return fieldDatas?.First()?.TextValue;
			}

			protected override ICollection<FieldData> PersistFieldDataInternal(object item)
			{
				var data = item as string;
				if (string.IsNullOrEmpty(data)) return new[] {new FieldData()};
				return new List<FieldData> {new FieldData {TextValue = data}};
			}
		}
	}
}