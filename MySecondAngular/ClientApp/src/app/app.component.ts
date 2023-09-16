import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'Elrouby Asks';
  SignedUsername: string = '';

  SignUsername(comp: any)
  {
    alert(comp.SendUsername);
    this.SignUsername = comp.SendUsername;
  }
}


