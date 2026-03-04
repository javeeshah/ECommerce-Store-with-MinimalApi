import { Injectable } from '@angular/core';
import { IProduct } from './product.model';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  cart: IProduct[] = [];

  constructor() {}

  addToCart(product: IProduct): void {
    this.cart = [...this.cart, product];
  }

  removeFromCart(productId: number): void {
    this.cart = this.cart.filter((item) => item.id != productId);
  }

  getCartItems(): IProduct[] {
    return this.cart;
  }

}
