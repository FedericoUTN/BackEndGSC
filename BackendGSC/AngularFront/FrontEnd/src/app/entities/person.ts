import { Address } from "./address";

export class Person {
    constructor(
    public firstName : string ,
    public lastName : string,
    public email : string,
    public address : Address,
    public id? : number
    ){
        this.address = new Address();
    }
    
}
