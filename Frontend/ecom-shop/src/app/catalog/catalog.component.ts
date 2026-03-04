import { Component } from '@angular/core';
import { ProductDetailsComponent } from "../product-details/product-details.compnent";
import { ProductsService } from '../products.service';
import { IProduct } from '../product.model';

@Component({
  selector: 'bot-catalog',
  templateUrl: './catalog.component.html',
  styleUrl: './catalog.component.css',
  imports: [ProductDetailsComponent],
})
export class CatalogComponent {
  products: IProduct[] = [];

  constructor(private productService: ProductsService) { 
    
  }

  ngOnInit(): void {
    this.products = this.productService.getproducts();
  }

}
