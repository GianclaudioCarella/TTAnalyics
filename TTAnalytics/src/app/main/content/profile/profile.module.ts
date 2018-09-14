import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { TranslateModule } from '@ngx-translate/core';

import { CdkTableModule } from '@angular/cdk/table';

import { MatButtonModule, MatDividerModule, MatFormFieldModule, MatIconModule, MatMenuModule, MatSelectModule, 
    MatSidenavModule, MatTableModule, MatTabsModule } from '@angular/material';

import { NgxChartsModule } from '@swimlane/ngx-charts';

import { FuseSharedModule } from '@fuse/shared.module';
import { FuseWidgetModule } from '@fuse/components/widget/widget.module';

import { ProfileComponent } from './profile.component';
import { ProfileService } from './profile.service';

const routes = [
    {
        path     : 'profile',
        component: ProfileComponent,
        //  resolve  : {
        //      data: ProfileService
        //  }
    }
];

@NgModule({
    declarations: [
        ProfileComponent
    ],
    imports     : [
        RouterModule.forChild(routes),

        CdkTableModule,
        MatButtonModule,
        MatDividerModule,
        MatFormFieldModule,
        MatIconModule,
        MatMenuModule,
        MatSelectModule,
        MatSidenavModule,
        MatTableModule,
        MatTabsModule,

        NgxChartsModule,

        FuseSharedModule,
        FuseWidgetModule
    ],
    providers   : [
        ProfileService
    ],
    exports     : [
        ProfileComponent
    ]
})

export class ProfileModule
{
}
