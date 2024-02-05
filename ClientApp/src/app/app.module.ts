import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

import { IndexComponent } from './components/private/main/index/index.component';
import { SignInComponent } from './components/public/signin/signin.component';
import { MainComponent } from './components/private/main/main.component';
import { PasswordRecoveryComponent } from './components/public/password-recovery/password-recovery.component';

import { Routes } from '@angular/router';
import { SalesComponent } from './components/private/main/sales/sales.component';
import { ShoppingComponent } from './components/private/main/shopping/shopping.component';
import { CostumersComponent } from './components/private/main/costumers/costumers.component';
import { InstallersComponent } from './components/private/main/installers/installers.component';
import { ConsultantsComponent } from './components/private/main/consultants/consultants.component';
import { AccountsComponent } from './components/private/main/accounts/accounts.component';
import { OrderServiceComponent } from './components/private/main/order-service/order-service.component';
import { CollectionOrderComponent } from './components/private/main/collection-order/collection-order.component';

const root_title = "SAED v1.0 / ";

const main: Routes = [
  { path: '', title: root_title + "Página Principal", component: IndexComponent },
  { path: 'Index', title: root_title + "Página Principal", component: IndexComponent },
  { path: 'Accounts', title: root_title + "Usuario", component: AccountsComponent },
  { path: 'CollectionOrder', title: root_title + "Orden de compra", component: CollectionOrderComponent },
  { path: 'Consultans', title: root_title + "Asesores", component: ConsultantsComponent },
  { path: 'Constumers', title: root_title + "Clientes", component: CostumersComponent },
  { path: 'Installers', title: root_title + "Instaladores", component: InstallersComponent },
  { path: 'OrderService', title: root_title + "Orden de servicio", component: OrderServiceComponent },
  { path: 'Sales', title: root_title + "Ventas", component: SalesComponent },
  { path: 'Shopping', title: root_title + "Compras", component: ShoppingComponent },
];

const routes: Routes = [
  { path: '', title:  root_title + "Iniciar Sesión", component: SignInComponent, pathMatch: 'full' },
  { path: 'Main', title:  root_title + "", component: MainComponent, children: main },
  { path: 'Password-Recovery', title: root_title + "Recuperar Contraseña", component: PasswordRecoveryComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    SignInComponent,
    MainComponent,
    PasswordRecoveryComponent,
    SalesComponent,
    ShoppingComponent,
    CostumersComponent,
    InstallersComponent,
    ConsultantsComponent,
    AccountsComponent,
    OrderServiceComponent,
    CollectionOrderComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
