import { Component } from '@angular/core';

@Component({
  selector: 'app-order-service',
  templateUrl: './order-service.component.html',
  styleUrls: ['./order-service.component.css']
})
export class OrderServiceComponent {
  public placeholderText: string = "Escribe Aquí";
  public placeholderPhone: string = "0000 0000 00";
  public placeholderEmail: string = "ejemplo@gmail.com";
}
