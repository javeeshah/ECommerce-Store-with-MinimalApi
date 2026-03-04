import { Component } from '@angular/core';
import { CartItemsComponent } from "../cart-items/cart-items.compnent";
import { IProduct } from '../product.model';

@Component({
  selector: 'bot-cart',
  imports: [CartItemsComponent],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css',
})
export class CartComponent {
  cartItems: IProduct[];

  constructor(private cartService: CartComponent) {
    this.cartItems = [];

  }

  ngOnInit(): void {
    this.cartItems = this.cartService.cartItems;
  }

}
