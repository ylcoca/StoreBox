
import { ProductType } from "./product-type.model";

export class Order {
  totalSize: number;
  products: Array<ProductType>

  constructor() {
    this.totalSize = 0;
    this.products = new Array<ProductType>();
  }
}


