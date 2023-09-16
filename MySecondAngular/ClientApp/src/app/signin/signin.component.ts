import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Inject, Output, SecurityContext } from '@angular/core';
import { Route, Router, UrlSegment } from '@angular/router';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent {

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string, public router: Router)
  {

  }
  SignIn(username: any, password: any)
  {
    this.http.get<boolean>(this.baseUrl + 'SignIn?username=' + username.value + '&password=' + password.value)
    .subscribe(result => {
      if (result)
      {
        window.localStorage.setItem('mainpage', '1');
        
        alert('Signed In Successfully');
        
        this.router.navigate(['/'], {
          queryParams: {
              value: username.value
          }
      });
      }
      else
      {
        alert('Username or Password is not match');
        return;
      }
    }, error => console.error(error));
  }
}
