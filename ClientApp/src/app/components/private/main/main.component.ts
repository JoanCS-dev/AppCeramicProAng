import {Component} from '@angular/core';
declare function Init(): void;
@Component({
  selector: 'app-main',
  templateUrl: './main.component.html'
})
export class MainComponent {
  
  constructor(){
    setTimeout(function(){
      Init();
    },200);
  }

  ngOnInit():void{
    
  }
  

}