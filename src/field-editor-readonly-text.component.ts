import { Component, ChangeDetectorRef, ChangeDetectionStrategy } from '@angular/core';
import { NgRedux } from '@angular-redux/store';
import { TranslateService } from '@ngx-translate/core';

import { IAppState, BaseFieldEditor, FormFieldActions } from 'litium-ui';

@Component({
    selector: 'field-editor-readonly-text',
    templateUrl: 'field-editor-readonly-text.component.html',
    changeDetection: ChangeDetectionStrategy.OnPush 
})

export class FieldEditorReadonlyText extends BaseFieldEditor {

    constructor(changeDetection: ChangeDetectorRef) {
        super(changeDetection);
    }

    public get viewItems(): any[] {
        return this.getValue(this.viewLanguage);
    }

    public set viewItems(value: any[]) {
        
    }
}