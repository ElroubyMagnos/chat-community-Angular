import { HttpClient } from '@angular/common/http';
import { Component, Inject, Input, EventEmitter } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-mainpage',
  templateUrl: './mainpage.component.html',
  styleUrls: ['./mainpage.component.css']
})
export class MainpageComponent {

  GotoChat(targetuser: string)
  {
    this.router.navigateByUrl('/private?un=' + targetuser);
  }
  CurrentUser = window.localStorage.getItem('username')?.toString();

  Accounts: Account[];

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string, private route:ActivatedRoute, private router:Router)
  {
    if (window.localStorage.getItem('mainpage') == '1')
    {
      window.localStorage.setItem('mainpage', '0');
      window.location.reload();
    }

    http.get<Account[]>(baseUrl + 'quesindex').subscribe(result => {
      this.Accounts = result;
    }, error => console.error(error));

    this.route.queryParams.subscribe((res) => {
    this.CurrentUser = res.value;
      if (res.value.length > 0)
      {
        window.localStorage.setItem('username', res.value);
      }
      
    });

    this.CurrentUser = window.localStorage.getItem('username')?.toString();
  }
}

interface Account
{
  ID: number;
  username: string;
  password: string;
}
