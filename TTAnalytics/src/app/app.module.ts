import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, Routes } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import 'hammerjs';

import { FuseModule } from '@fuse/fuse.module';
import { FuseSharedModule } from '@fuse/shared.module';

import { fuseConfig } from './fuse-config';

import { AppComponent } from './app.component';
import { FuseMainModule } from './main/main.module';

// NUEVOS 
import { DashboardModule } from './main/content/dashboard/dashboard.module';
import { ProfileModule } from './main/content/profile/profile.module';
import { AuthService } from './auth/auth.service';

const appRoutes: Routes = [
    {
        path      : '**',
        redirectTo: 'dashboard'
    },
    {
        path      : '**',
        redirectTo: 'profile'
    }
];

@NgModule({
    declarations: [
        AppComponent
    ],
    imports     : [
        BrowserModule,
        BrowserAnimationsModule,
        HttpClientModule,
        RouterModule.forRoot(appRoutes),
        TranslateModule.forRoot(),

        // Fuse Main and Shared modules
        FuseModule.forRoot(fuseConfig),
        FuseSharedModule,
        FuseMainModule,
        DashboardModule,
        ProfileModule
    ],
    bootstrap   : [
        AppComponent
    ],
    providers: [AuthService],
})
export class AppModule
{
}
