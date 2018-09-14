import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';

import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class ProfileService implements Resolve<any>
{
    timeline: any;
    about: any;
    photosVideos: any;

    timelineOnChanged: BehaviorSubject<any> = new BehaviorSubject({});
    aboutOnChanged: BehaviorSubject<any> = new BehaviorSubject({});
    photosVideosOnChanged: BehaviorSubject<any> = new BehaviorSubject({});

    constructor(private http: HttpClient)
    {
    }

    /**
     * Resolve
     * @param {ActivatedRouteSnapshot} route
     * @param {RouterStateSnapshot} state
     * @returns {Observable<any> | Promise<any> | any}
     */
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<any> | Promise<any> | any
    {
        return new Promise((resolve, reject) => {
            Promise.all([
                this.getAbout()
            ]).then(
                () => {
                    resolve();
                },
                reject
            );
        });
    }

    /**
     * Get about
     */
    getAbout(): Promise<any[]>
    {
        return new Promise((resolve, reject) => {
            resolve(this.about);
             this.http.get('api/profile-about')
                 .subscribe((about: any) => {
                     this.about = about;
                     this.aboutOnChanged.next(this.about);
                    resolve(this.about);
                 }, reject);
        });
    }
}
