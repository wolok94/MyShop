import { CategoryModel } from "./category.model";

export interface ProductModel{
    id:number;
    title:string;
    description:string;
    price:number;
    category:CategoryModel;
}