import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main-index',
  templateUrl: './index.component.html'
})
export class IndexComponent {
  public placeholderText: string = "Escribe Aquí";
  public placeholderPhone: string = "0000 0000 00";
  public placeholderEmail: string = "ejemplo@gmail.com";
  accountName: string = ""
  constructor(){
    this.accountName = localStorage.getItem("fullName")??"Sin dato";
  }
}