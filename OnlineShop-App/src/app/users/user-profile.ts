import { Address } from './address';

export interface UserProfile {
    id: string;
    username: string;
    name: string;
    surname: string;
    addresses: Address[];
}
