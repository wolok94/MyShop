import { ProductModel } from "./product.model";

export interface CategoryModel {
    categoryId: number;
    name : string;
    products : ProductModel[];
}