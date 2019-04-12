import { Photo } from './photos/Photo';

export interface Product {
  id: number;
  name: string;
  description?: string;
  price: number;
  photoURL: string;
  photos?: Photo[];
}
