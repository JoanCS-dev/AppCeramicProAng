import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main-index',
  templateUrl: './index.component.html'
})
export class IndexComponent {
  accountName: string = ""
  constructor(){
    this.accountName = localStorage.getItem("fullName")??"Sin dato";
  }
}