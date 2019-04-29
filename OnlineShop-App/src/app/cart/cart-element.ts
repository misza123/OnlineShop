import { Product } from '../products/product';

export interface CartElement {
    id: number;
    count: number;
    product: Product;
}
