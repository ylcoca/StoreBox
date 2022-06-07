import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Order } from "./order.model";

@Injectable({
  providedIn: "root",
})
export class OrderService {
  readonly _baseUrl = "https://localhost:5001/api/";
  formData: Order = new Order();
  list: Order = new Order();

  constructor(private http: HttpClient) { }

  postMember() {
    return this.http.post(this._baseUrl, this.formData);
  }
  listOrderById() {
    return this.http.get(this._baseUrl + "Order/10")
      .toPromise()
      .then(res => this.list = res as Order);
  }
}
