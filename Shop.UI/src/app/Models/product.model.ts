import { CategoryModel } from "./category.model";
import { CommentModel } from "./comment.model";

export class ProductModel{
    id:number;
    title:string;
    description:string;
    price:number;
    category:CategoryModel;
    imageUrl:string;
    comments : CommentModel[];
    numberOfProducts : number = 1;
}