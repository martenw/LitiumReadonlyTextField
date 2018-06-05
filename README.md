# LitiumReadonlyTextField

A field definition for Litium field framework.

ReadonlyText is a textfield that cannot be modified in Litium backoffice, useful when value is only modified through API, for example when value is set through integration.

UI is only implemented as an Angular component which verks with:
* PIM, versions > 6.2
* Media, versions > 6
* Customers, versions > 6

Example field in view mode:

![Example field in view mode](/screenshots/readonlytextview.png?raw=true "Example field in view mode")

Example field in edit mode:

![Example field in edit mode](/screenshots/readonlytextedit.png?raw=true "Example field in edit mode")

## Installation instructions

Background and more information on creating fields can be found at [Litium docs site](https://docs.litium.com/documentation/architecture/field-framework/creating-a-custom-field-type).

1. Copy the files from \src to the following paths in your Litium Accelerator solution 
```
\src\Litium.Accelerator\FieldFramework\ReadonlyText.cs
\src\Accelerator\components\field-editor-readonly-text\field-editor-readonly-text.component.html
\src\Accelerator\components\field-editor-readonly-text\field-editor-readonly-text.component.ts
```
1. To register the component edit the file `src\Accelerator\components\index.ts` and add the line: `export { FieldEditorReadonlyText } from './field-editor-readonly-text/field-editor-readonly-text.component';`
1. Modify `src\Accelerator\extensions.ts` and add _FieldEditorReadonlyText_ to `import { FieldEditorReadonlyText, ... } from './components';` and to `declarations: [ FieldEditorReadonlyText, ... ]`
1. Build the typescript following [instructions on Litium docs site](https://docs.litium.com/documentation/architecture/field-framework/creating-a-custom-field-type), run the following commands from a command prompt in directory _src\Litium.Accelerator.FieldTypes_
    1. `npm install` 
    1. `npm run build`
1. Build your solution
1. In Litium backoffice you should now be able to create fields with the new `ReadonlyText` fieldtype and add it to field templates.
1. Add a value for the field using API: `myEntity.Fields.AddOrUpdateValue("ReadonlyTextField", "Value that user cannot edit");`


