import {Component, ViewChild} from '@angular/core';
import { Router } from '@angular/router';
declare function Init(): void;
@Component({
  selector: 'app-main',
  templateUrl: './main.component.html'
})
export class MainComponent {

  @ViewChild('btnTriggerModalLogOut') btnTriggerModalLogOut: any
  strEmail: string = "";
  strName: string = "";
  
  constructor(private router: Router){
    this.strEmail = localStorage.getItem("strEmail")??"Sin dato";
    this.strName = localStorage.getItem("fullName")??"Sin dato";
    setTimeout(function(){
      Init();
    },200);
  }

  ngOnInit():void{
    
  }
  
  showModalLogOut():void{
    this.btnTriggerModalLogOut.nativeElement.click();
  }

  logOut(): void {
    localStorage.clear();
    this.router.navigate(['/']);
  }

}