import { Component, OnInit, ViewEncapsulation } from '@angular/core';

import { fuseAnimations } from '@fuse/animations';
import { ProfileService } from './profile.service';
import { AuthService } from '../../../auth/auth.service';

@Component({
    selector     : 'fuse-profile',
    templateUrl  : './profile.component.html',
    styleUrls    : ['./profile.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations   : fuseAnimations
})
export class ProfileComponent implements OnInit
{
    about: any;
    profile: any;
    
    constructor(
        private profileService: ProfileService, 
        public auth: AuthService)
    {
        this.about = 
        {
            general: {

                gender: 'Masculino',
                birthday: '17/06/1986',
                locations: ['Brasil'],
                about: 'Teste'
            },
        };

        

        // this.profileService.aboutOnChanged.subscribe(about => {
        //     this.about = about;
        // });
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
