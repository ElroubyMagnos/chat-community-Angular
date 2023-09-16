import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string)
  {

  }

  EnterData(username: any, password: any, cpassword: any)
  {
    if (username.value.length < 4 || password.value.length < 4)
    {
      alert('Username and password must be more than 4 characters');
      return;
    }
    if (password.value != cpassword.value)
    {
      alert('Password is not match');
      return;
    }

    this.http.get<boolean>(this.baseUrl + 'Check?username=' + username.value)
    .subscribe(result => {
      if (result)
      {
        alert('Username already exists');
        return;
      }
      else
      {
        this.http.get(this.baseUrl + 'SignUpDataEntry?username=' + username.value + '&password=' + password.value).subscribe();
        alert('Account Created Successfully!');
      }
    }, error => console.error(error));

    username.value = '';
    password.value = '';
    cpassword.value = '';
    
  }
}
