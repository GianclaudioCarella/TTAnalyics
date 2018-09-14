import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { DataSource } from '@angular/cdk/collections';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import * as shape from 'd3-shape';

import { FuseTranslationLoaderService } from '@fuse/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as turkish } from './i18n/tr';

import { fuseAnimations } from '@fuse/animations';
import { DashboardService } from './dashboard.service';
import { AuthService } from '../../../auth/auth.service';

@Component({
    selector   : 'fuse-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls  : ['./dashboard.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations   : fuseAnimations
})
export class DashboardComponent implements OnInit
{

    profile: any;

    constructor(
        private dashboardService: DashboardService, 
        public auth: AuthService
    )
    {
        
    }

    ngOnInit() {
        if (this.auth.userProfile) {
          this.profile = this.auth.userProfile;
        } else {
          this.auth.getProfile((err, profile) => {
            this.profile = profile;
          });
        }
    
      }
}

