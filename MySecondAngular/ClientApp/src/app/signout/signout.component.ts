import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signout',
  templateUrl: './signout.component.html',
  styleUrls: ['./signout.component.css']
})
export class SignoutComponent {
  constructor(public router: Router)
  {
    window.localStorage.setItem('username', '');
    window.localStorage.setItem('mainpage', '1');
    this.router.navigate(['/']);
  }
}
