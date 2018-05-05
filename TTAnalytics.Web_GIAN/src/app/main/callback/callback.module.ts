import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MatButtonModule, MatIconModule, MatToolbarModule } from '@angular/material';

import { FuseSharedModule } from '@fuse/shared.module';

import { CallbackComponent } from './callback.component';

@NgModule({
    declarations: [
        CallbackComponent
    ],
    imports     : [
        RouterModule,

        MatButtonModule,
        MatIconModule,
        MatToolbarModule,

        FuseSharedModule
    ],
    exports     : [
        CallbackComponent
    ]
})
export class CallbackModule
{
}
