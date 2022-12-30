import { CategoryModel } from "./category.model";
import { CommentModel } from "./comment.model";

export interface ProductModel{
    id:number;
    title:string;
    description:string;
    price:number;
    category:CategoryModel;
    imageUrl:string;
    comments : CommentModel[];
}