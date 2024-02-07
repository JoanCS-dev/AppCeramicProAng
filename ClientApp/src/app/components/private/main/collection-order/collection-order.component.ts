import { Component } from '@angular/core';

@Component({
  selector: 'app-collection-order',
  templateUrl: './collection-order.component.html',
  styleUrls: ['./collection-order.component.css']
})
export class CollectionOrderComponent {
  public placeholderText: string = "Escribe Aquí";
  public placeholderPhone: string = "0000 0000 00";
  public placeholderEmail: string = "ejemplo@gmail.com";
  constructor(){
  }
}
