import { Injectable } from '@angular/core';
import { IProduct } from './product.model';
import allProducts from './products.json';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  getproducts(): IProduct[] {
     return allProducts;
  }
}