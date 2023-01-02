import { RouterLink } from "@angular/router";
import { AddressModel } from "./address.model";
import { OrderModel } from "./order.model";
import { ProductModel } from "./product.model";
import { RoleModel } from "./role.model";
import { ShoppingCartModel } from "./shopping-cart.model";

export class UserModel {
    id : number;
    email : string;
    nickName : string;
    address : AddressModel;
    addressId : number;
    role : RoleModel;
    roleId : number;
    firstName : string;
    lastName : string;
    orders : OrderModel[];
    shoppingCart : ShoppingCartModel;
}