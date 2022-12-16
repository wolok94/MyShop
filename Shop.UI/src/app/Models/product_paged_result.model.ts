import { ProductModel } from "./product.model";

export interface ProductPagedResultModel{
    products: ProductModel[];
    totalPages: number;
    itemsFrom: number;
    itemsTo: number;
    totalItemsCount: number;

}