import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';

import { IndexComponent } from './components/private/main/index/index.component';
import { SignInComponent } from './components/public/signin/signin.component';
import { MainComponent } from './components/private/main/main.component';
import { PasswordRecoveryComponent } from './components/public/password-recovery/password-recovery.component';

import { Routes } from '@angular/router';

const root_title = "SAED v1.0 / ";

const main: Routes = [
  { path: '', title: root_title + "Página Principal", component: IndexComponent },
  { path: 'Index', title: root_title + "Página Principal", component: IndexComponent },
];

const routes: Routes = [
  { path: '', title:  root_title + "Iniciar Sesión", component: SignInComponent, pathMatch: 'full' },
  { path: 'Main', title:  root_title + "", component: MainComponent, children: main },
  { path: 'Password-Recovery', title: root_title + "Recuperar Contraseña", component: PasswordRecoveryComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    FetchDataComponent,
    IndexComponent,
    SignInComponent,
    MainComponent,
    PasswordRecoveryComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
