import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { CommonModule } from "@angular/common";
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { MainpageComponent } from './mainpage/mainpage.component';
import { SigninComponent } from './signin/signin.component';
import { SignupComponent } from './signup/signup.component';
import { PrivatechatComponent } from './privatechat/privatechat.component';
import { SignoutComponent } from './signout/signout.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    MainpageComponent,
    SigninComponent,
    SignupComponent,
    SignoutComponent,
    PrivatechatComponent
  ],
  imports: [
    CommonModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: MainpageComponent  },
      { path: 'signup', component: SignupComponent  },
      { path: 'signin', component: SigninComponent  },
      { path: 'private', component: PrivatechatComponent  },
      { path: 'signout', component: SignoutComponent  },
      { path: 'signout', component: SignoutComponent  },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
