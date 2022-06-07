import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from '../shared/order.model';
import { OrderService } from '../shared/order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styles: [
  ]
})
export class OrderComponent implements OnInit {

  list: Order

  constructor(public service: OrderService) {
    this.list = {
      totalSize : 0,
      products : []
    };
}

  async ngOnInit() {
    this.list = await this.service.listOrderById();
    console.log(this.list)
  }
}
