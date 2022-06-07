import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Order } from '../../shared/order.model';
import { OrderService } from '../../shared/order.service';

@Component({
  selector: 'app-order-form',
  templateUrl: './order-form.component.html',
  styles: [
  ]
})
export class OrderFormComponent implements OnInit {

  constructor(public service: OrderService) {
  }

  ngOnInit(): void {
  }


}
