import { ProductModel } from "./product.model";

export interface ShoppingCartModel{
    id:number;
    products: ProductModel[];
    nickName: string;
    userId: number;
}