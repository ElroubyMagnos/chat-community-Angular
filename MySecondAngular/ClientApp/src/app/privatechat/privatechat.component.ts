import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-privatechat',
  templateUrl: './privatechat.component.html',
  styleUrls: ['./privatechat.component.css']
})
export class PrivatechatComponent {
  msg: Message[] = [];

  sender: any;
  receiver: string;

  SendPrivateMessage(msg: string)
  {
    this.http.get(this.baseUrl + 'SendMessage?sender=' + this.sender + '&receiver=' + this.receiver + "&message=" + msg).subscribe();
    this.http.get<Message[]>(this.baseUrl + 'GetMessages?sender=' + this.sender + '&receiver=' + this.receiver)
    .subscribe(result => {
      this.msg = result;
    });
  }

  constructor(public route: Router, public http: HttpClient, @Inject('BASE_URL') public baseUrl: string)
  {
    this.receiver = location.href.split('un=')[1];
    this.sender = window.localStorage.getItem('username');

    if (this.receiver == this.sender)
    {
      alert('You cannot chat with yourself');
      this.route.navigate(['/']);
    }
    else if (this.receiver.length == 0 || this.sender.length == 0)
    {
      alert('one of chatters is not available');
      this.route.navigate(['/']);
    }

    this.http.get<Message[]>(this.baseUrl + 'GetMessages?sender=' + this.sender + '&receiver=' + this.receiver)
    .subscribe(result => {
      this.msg = result;
    });
  } 
}

interface Message
{
  id: number;
  sender: string;
  receiver: string;
  message: string;
}
