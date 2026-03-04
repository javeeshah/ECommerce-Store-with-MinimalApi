import { Component, signal, WritableSignal, input } from '@angular/core';
import { IProduct } from '../product.model';
import { CurrencyPipe, NgClass } from '@angular/common';
import { CartService } from '../cart.service';

@Component({
  selector: 'bot-cart-items',
  imports: [CurrencyPipe, NgClass],
  templateUrl: './cart-items.component.html',
  styleUrl: './cart-items.component.css',
})

export class CartItemsComponent {
  product = input.required<IProduct>();

  constructor(private cartService: CartService) {

  }
    
  getImagePath(): string {
    return `images/robot-parts/${this.product().imageName}`;
  }

  removeFromCart(event: MouseEvent): void {    
    this.cartService.removeFromCart(this.product().id);
    console.log(event);
  }

  getPriceClass() {
    return {
      strikethrough: this.product().discount > 0      
    };
  }
}
