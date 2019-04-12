import { Product } from 'src/app/products/product';

export interface Order {
    id: number;
    userId: number;
    products: Product[];
    dateOfSubmission: Date;
    dateOfShipment?: Date;
}
