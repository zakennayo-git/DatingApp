import { catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { AlertifyService } from './../_services/alertify.service';
import { UserService } from './../_services/user.service';
import { Injectable } from '@angular/core';
import { User } from '../_models/user';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';

@Injectable()
export class MemberDetailResolver implements Resolve<User> {
  constructor(private userService: UserService, private router: Router, private alertify: AlertifyService) {  }

    resolve(router: ActivatedRouteSnapshot): Observable<User> {
      return this.userService.getUser(router.params['id']).pipe(
        catchError(error => {
          this.alertify.error('Problem retriving data');
          this.router.navigate(['/members']);
          return of(null);
        })
      );
    }

}
