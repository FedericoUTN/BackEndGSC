import { Address } from "./address";

export interface Iperson {
    firstName: string | undefined;
    lastName: string | undefined;
    email: string | undefined;
    address?: Address | undefined;
    //addressId: number;
    loans?: any | undefined;
    id?: number | undefined;
}
